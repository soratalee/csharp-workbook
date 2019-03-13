using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<PhotoDbContext> builder = new DbContextOptionsBuilder<PhotoDbContext>();
            SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=PhotosDb;Trusted_Connection=true;");
            builder.UseSqlServer(connection);
            DbContextOptions<PhotoDbContext> opts = builder.Options;
            PhotoDbContext context = new PhotoDbContext(opts);

            context.Database.EnsureCreated();

            bool Done = false;
            bool CorrectInput = false;
            int num = 0;

            string userInputOptions = "";
            string userInputTitle = "";
            string userInputLocation = "";
            string userInputDescription = "";
            string userInputRating = "";

            string userEditOptions = "";
            string userEditing = "";
            string userSearch = "";
            string userEditIdSelect = "";
            while (Done != true)
            {
                Console.WriteLine("Do you want to CREATE, SEARCH, EDIT, or REMOVE an entry? Type DISPLAY to view all entries.");
                userInputOptions = Console.ReadLine().ToUpper();

                Photos Entry = new Photos();

                if (userInputOptions == "CREATE" || userInputOptions == "SEARCH" || userInputOptions == "EDIT" || userInputOptions == "REMOVE" || userInputOptions == "DISPLAY" || userInputOptions == "DONE")
                {
                    if (userInputOptions == "CREATE")
                    {
                        Console.WriteLine("What will your Title be?");
                        userInputTitle = Console.ReadLine();
                        Console.WriteLine("Where is this stored?");
                        userInputLocation = Console.ReadLine();
                        Console.WriteLine("Enter in a description:");
                        userInputDescription = Console.ReadLine();
                        CorrectInput = false;
                        while (CorrectInput != true)
                        {
                            Console.WriteLine("Give it a rating (1-5):");
                            userInputRating = Console.ReadLine();
                            if (!int.TryParse(userInputRating, out num))
                            {
                                Console.WriteLine("Please enter in values 1-5 only!");
                                CorrectInput = false;
                            }
                            else
                            {
                                if (Convert.ToInt16(userInputRating) > 0 && Convert.ToInt16(userInputRating) < 6)
                                {
                                    Entry = new Photos
                                    {
                                        Title = userInputTitle,
                                        CreateDate = DateTime.Now,
                                        Location = userInputLocation,
                                        Description = userInputDescription,
                                        Rating = Convert.ToInt16(userInputRating)
                                    };
                                    context.Photos.Add(Entry);
                                    CorrectInput = true;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter in values 1-5 only!");
                                    CorrectInput = false;
                                }
                            }
                        }
                    }

                    else if (userInputOptions == "SEARCH")
                    {
                        CorrectInput = false;
                        while (CorrectInput != true)
                        {
                            Console.WriteLine("Which field do you want to search by?[TITLE, LOCATION, DESCRIPTION, RATING]");
                            userEditOptions = Console.ReadLine().ToUpper();

                            if (userEditOptions == "TITLE" || userEditOptions == "LOCATION" || userEditOptions == "DESCRIPTION" || userEditOptions == "RATING")
                            {
                                Console.WriteLine("Enter in the {0} you want to look up:", userEditOptions);
                                userSearch = Console.ReadLine();

                                string sqltext = "SELECT * from Photos a where " + userEditOptions + " = '" + userSearch + "'";
                                SqlCommand cmd = new SqlCommand(sqltext, connection);

                                connection.Open();
                                SqlDataReader reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    Console.WriteLine("ID|Title|Location|Description|Rating|CreateDate");
                                    foreach (var entry in reader)
                                    {
                                        Console.WriteLine(string.Format("{0}, {1}, {2}, {3}, {4}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]));
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("There is nothing matching your criteria.");
                                    connection.Close();
                                }
                                CorrectInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter only one of the following: [TITLE, LOCATION, DESCRIPTION, RATING]!");
                                CorrectInput = false;
                            }
                        }
                    }
                    else if (userInputOptions == "EDIT")
                    {
                        CorrectInput = false;
                        while (CorrectInput != true)
                        {
                            Console.WriteLine("Which field do you want to edit?[TITLE, LOCATION, DESCRIPTION, RATING]");
                            userEditOptions = Console.ReadLine().ToUpper();

                            if (userEditOptions == "TITLE" || userEditOptions == "LOCATION" || userEditOptions == "DESCRIPTION" || userEditOptions == "RATING")
                            {
                                Console.WriteLine("Enter in the Id of the {0} you want changed:", userEditOptions);
                                userEditIdSelect = Console.ReadLine();
                                if (!int.TryParse(userEditIdSelect, out num))
                                {
                                    Console.WriteLine("Please enter an Id number value only!");
                                    CorrectInput = false;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter in a new {0}:", userEditOptions);
                                    userEditing = Console.ReadLine();

                                    string sqltext = "UPDATE a set " + userEditOptions + " = '" + userEditing + "' from Photos a where Id = " + userEditIdSelect.ToString();
                                    SqlCommand cmd = new SqlCommand(sqltext, connection);

                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                    CorrectInput = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter in values [TITLE, LOCATION, DESCRIPTION, RATING] only!");
                                CorrectInput = false;
                            }
                        }
                    }
                    else if (userInputOptions == "REMOVE")
                    {
                        CorrectInput = false;
                        while (CorrectInput != true)
                        {
                            Console.WriteLine("Enter in the Id of the entry you want removed:");
                            userEditIdSelect = Console.ReadLine();
                            if (int.TryParse(userEditIdSelect, out num))
                            {
                                Console.WriteLine("Please enter an Id number value only!");
                                CorrectInput = false;
                            }
                            else
                            {

                                string sqltext = "DELETE from Photos where Id = " + userEditIdSelect.ToString();
                                Console.WriteLine(sqltext);
                                SqlCommand cmd = new SqlCommand(sqltext, connection);

                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                                CorrectInput = true;
                            }
                        }
                    }
                    else if (userInputOptions == "DISPLAY")
                    {
                        CorrectInput = false;
                        connection.Open();
                        Console.WriteLine("ID|Title|Location|Description|Rating|CreateDate");
                        foreach (var entry in context.Photos)
                        {
                            Console.WriteLine(entry.Id + ", " + entry.Title + ", " + entry.Location + ", " + entry.Description + ", " + entry.Rating + ", " + entry.CreateDate);
                        }
                        connection.Close();
                    }
                    else if (userInputOptions == "DONE")
                    {
                        Done = true;
                    }

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Please enter only the following: CREATE, SEARCH, EDIT, or REMOVE ");
                    CorrectInput = false;
                }
            }
            Console.ReadLine();
        }
    }
}
