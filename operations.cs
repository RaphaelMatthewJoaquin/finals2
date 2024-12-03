using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQL
{
    internal class operations
    {

        SqlConnection cs = new SqlConnection("Data Source= localhost; Initial Catalog = warframe; Integrated Security= true");
        Rate110 r = new Rate110();
        gameplay g = new gameplay();


        public void view()
        {


            cs.Open();
            Console.ForegroundColor = ConsoleColor.Magenta;

            SqlCommand selcommand = new SqlCommand("Select * from frame", cs);

            SqlDataReader dr = selcommand.ExecuteReader();



            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["ID"]);
                string name = dr["NAME"].ToString();
                string role = dr["ROLE"].ToString();
                string game = dr["GAMEPLAY"].ToString();
                int rate = Convert.ToInt32(dr["RATE"]);

                Console.WriteLine("ID: " + id + "\tNAME: " + name + "\tROLE:" + role + "\tGAMEPLAY: " + game + "\tRATING: " + rate);
            }

            dr.Close();
            cs.Close();
        }

        public void add()
        {
            Console.Write("\n-ENTER FRAME DETAILS-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Beep();
            Console.Write("\nENTER NAME OF FRAME: ");
            string name = Console.ReadLine().ToUpper();
            Console.Beep();
            Console.Write("\nENTER IT's ROLE: ");
            string role = Console.ReadLine().ToUpper();
            Console.Beep();
            Console.Write("\nENTER THE PLAYSTYLE: ");
            string game = g.game();
            Console.Beep();
            int rate = r.rate();


            //try
            //{
            cs.Open();

            SqlCommand insertcommand = new SqlCommand("Insert into frame (NAME, ROLE, GAMEPLAY, RATE) VALUES (@NAME, @ROLE, @GAMEPLAY, @RATE)", cs);
            insertcommand.Parameters.Add("@NAME", SqlDbType.VarChar).Value = name;
            insertcommand.Parameters.Add("@ROLE", SqlDbType.VarChar).Value = role;
            insertcommand.Parameters.Add("@GAMEPLAY", SqlDbType.VarChar).Value = game;
            insertcommand.Parameters.Add("@RATE", SqlDbType.Int).Value = rate;
            insertcommand.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FRAME ADDED TO ARSENAL");

            cs.Close();
            //}
            //catch
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Error.");
            //}
        }

        public void search()
        {
            Console.Beep();
            Console.Write("\n ENTER FRAME ID TO SEARCH: ");
            string search = Console.ReadLine();

            cs.Open();

            SqlCommand selectCommand = new SqlCommand("Select * from frame where ID = @ID", cs);
            selectCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = search;
            SqlDataReader dr = selectCommand.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nFRAME FOUND!!");
                int id = Convert.ToInt32(dr["ID"]);
                string name = dr["NAME"].ToString();
                string role = dr["ROLE"].ToString();
                string game = dr["GAMEPLAY"].ToString();
                int rate = Convert.ToInt32(dr["RATE"]);

                Console.WriteLine("ID: " + id + "\tNAME: " + name + "\tROLE: " + role + "\t\tGAMEPLAY: " + game + "\tRATING: " + rate);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: FRAME NOT FOUND");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("WOULD YOU LIKE TO ADD?(Y/N): ");
                Console.Beep();
                string reply = Console.ReadLine().ToUpper();

                bool run = true;
                
                while (run)
                {


                    if (reply == "Y")
                    {
                        run = false;
                        cs.Close();
                        add();
                    }

                    else if (reply == "N")
                    {
                        run = false;
                        bool run2 = true;
                        while (run2)
                        {
                            Console.Write("WOULD YOU LIKE TO VIEW LIST INSTEAD?(Y/N): ");
                            string reply2 = Console.ReadLine().ToUpper();
                            if (reply2 == "Y")
                            {
                                Console.WriteLine("VIEWING LIST");
                                cs.Close();
                                view();

                            }
                            else if (reply2 == "N")
                            {
                               Console.WriteLine("GOING BACK TO MENU");
                                run2 = false;
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("INVALID INPUT");
                            }
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("INVALID INPUT");
                    }
                }
            }

            cs.Close();

        }

        public void update()
        {
            Console.Beep();
            Console.Write("\n ENTER FRAME ID TO SEARCH: ");
            string search = Console.ReadLine();

            cs.Open();

            SqlCommand selectCommand = new SqlCommand("Select * from frame where ID = @ID", cs);
            selectCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = search;
            SqlDataReader dr = selectCommand.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nFRAME FOUND!!");

                //ENTER HERE
                Console.Write("\n-ENTER FRAME DETAILS TO UPDATE-");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Beep();
                Console.Write("\nENTER NAME OF FRAME: ");
                string name = Console.ReadLine().ToUpper();
                Console.Beep();
                Console.Write("\nENTER IT's ROLE: ");
                string role = Console.ReadLine().ToUpper();
                Console.Beep();
                Console.Write("\nENTER THE PLAYSTYLE: ");
                string game = Console.ReadLine().ToUpper();
                Console.Beep();
                int rate = r.rate();

                SqlCommand update = new SqlCommand("Update frame SET NAME=@NAME, ROLE=@ROLE, GAMEPLAY=@GAMEPLAY, RATE=@RATE where ID=@ID",cs);
                update.Parameters.Add("@NAME", SqlDbType.VarChar).Value = name;
                update.Parameters.Add("@ROLE", SqlDbType.VarChar).Value = role;
                update.Parameters.Add("@GAMEPLAY", SqlDbType.VarChar).Value = game;
                update.Parameters.Add("@RATE", SqlDbType.Int).Value = rate;
                update.Parameters.Add("@ID", SqlDbType.Int).Value = search;
                dr.Close();
                dr = update.ExecuteReader();
                Console.WriteLine("\nENTRY UPDATED");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: FRAME NOT FOUND");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("WOULD YOU LIKE TO ADD?(Y/N): ");
                Console.Beep();
                string reply = Console.ReadLine().ToUpper();

                bool run = true;

                while (run)
                {


                    if (reply == "Y")
                    {
                        run = false;
                        cs.Close();
                        add();
                      
                    }

                    else if (reply == "N")
                    {

                        run = false;
                        bool run2 = true;
                        while (run2)
                        {
                            Console.Write("WOULD YOU LIKE TO VIEW LIST INSTEAD?(Y/N): ");
                            string reply2 = Console.ReadLine().ToUpper();
                            if (reply2 == "Y")
                            {
                                Console.WriteLine("VIEWING LIST");
                                cs.Close();
                                view();

                            }
                            else if (reply2 == "N")
                            {
                                Console.WriteLine("GOING BACK TO MENU");
                                run2 = false;

                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("INVALID INPUT");
                    }
                }
            }

            cs.Close();
        }

        public void delete()
        {
            Console.Beep();
            Console.Write("\n ENTER FRAME ID TO DELETE: ");
            string search = Console.ReadLine();

            cs.Open();

            SqlCommand selectCommand = new SqlCommand("Select * from frame where ID = @ID", cs);
            selectCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = search;
            SqlDataReader dr = selectCommand.ExecuteReader();
            bool run = true;
            while (run)
            {
                if (dr.HasRows)
                {
                    run = false;
                    dr.Read();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nFRAME FOUND!!");
                    int id = Convert.ToInt32(dr["ID"]);
                    string name = dr["NAME"].ToString();
                    string role = dr["ROLE"].ToString();
                    string game = dr["GAMEPLAY"].ToString();
                    int rate = Convert.ToInt32(dr["RATE"]);

                    Console.WriteLine("ID: " + id + "\tNAME: " + name + "\tROLE: " + role + "\t\tGAMEPLAY: " + game + "\tRATING: " + rate+"\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ARE YOU SURE YOU WANT TO DELETE THIS ENTRY?(Y/N): ");
                    string reply = Console.ReadLine().ToUpper();


                    bool run2 = true;
                    while (run2)
                    {
                        if (reply == "Y")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            SqlCommand delete = new SqlCommand("Delete from frame where ID=@ID", cs);
                            delete.Parameters.Add("@ID", SqlDbType.Int).Value = search;
                            dr.Close();
                            dr = delete.ExecuteReader();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("ENTRY DELETED :(\n");
                            run2 = false;
                        }
                        else if (reply == "N")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("ENTRY DELETED");
                            Thread.Sleep(2000);
                            Console.Write("  .");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(1000);
                            Console.Write(".");
                            Thread.Sleep(2000);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("JUST KIDDING :3");
                            run2 = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("INVALID INPUT, JUST GIVE IT TO ME STRAIGHT");
                        }
                    }



                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ENTRY NOT FOUND");

                }
            }
            
        }

    }
}
