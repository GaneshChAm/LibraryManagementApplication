using Spectre.Console;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace LibraryManagementSystem
{    
    public class Library : IlibraryMangeApp
    {
        SqlConnection con = new SqlConnection("Server=US-CJB79S3; database=LibrarayMangementSystem; Integrated Security=true");
        public int AddBook()
        {
            try
            {
                con.Open();
                SqlCommand cmdib = new SqlCommand($"Insert into Books Values(@BookTitle,@BookAuthor,@BookQuantity)", con);
                AnsiConsole.MarkupLine($"[Blue]Enter the Book Details To Add  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book Title:  [/] ");
                string titi = Console.ReadLine();
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book Author:  [/] ");
                string auti = Console.ReadLine();
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book Quantity:  [/] ");
                int quai = Convert.ToInt16(Console.ReadLine());
                cmdib.Parameters.AddWithValue("@BookTitle", titi);
                cmdib.Parameters.AddWithValue("@BookAuthor", auti);
                cmdib.Parameters.AddWithValue("@BookQuantity", quai);
                cmdib.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Book Details saved successfully [/] ");
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Adding Book: {ex.Message} [/] ");
                return 0;
            }
        }
        public int EditBook()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the Book Details To Edit  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the BookID to Edit :  [/] ");
                int idub = Convert.ToInt16(Console.ReadLine());
                SqlCommand checkCmd1 = new SqlCommand("Select Count(*) From Books Where BookID = @BookID", con);
                checkCmd1.Parameters.AddWithValue("@BookID", idub);
                int bookCount = (int)checkCmd1.ExecuteScalar();
                if (bookCount == 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Book ID not Found ! [/] ");
                    con.Close();
                    return 0;
                }
                SqlCommand cmdub = new SqlCommand($"Update Books Set BookTitle=@BookTitle, BookAuthor=@BookAuthor, BookQuantity=@BookQuantity Where BookID=@BookID", con);
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book Title:  [/] ");
                string titu = Console.ReadLine();
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book Author:  [/] ");
                string autu = Console.ReadLine();
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book Quantity:  [/] ");
                int quau = Convert.ToInt16(Console.ReadLine());
                cmdub.Parameters.AddWithValue("@BookID", idub);
                cmdub.Parameters.AddWithValue("@BookTitle", titu);
                cmdub.Parameters.AddWithValue("@BookAuthor", autu);
                cmdub.Parameters.AddWithValue("@BookQuantity", quau);
                cmdub.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Book Details Edited Successfully  [/] ");
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Editing Book: {ex.Message} [/] ");
                return 0;
            }
        }
        public int DeleteBook()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the Book Details To Delete  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the BookID to Delete :  [/] ");
                int iddb = Convert.ToInt16(Console.ReadLine());
                SqlCommand checkCmd2 = new SqlCommand("Select Count(*) From Books Where BookID = @BookID", con);
                checkCmd2.Parameters.AddWithValue("@BookID", iddb);
                int bookCount = (int)checkCmd2.ExecuteScalar();
                if (bookCount == 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Book ID not Found ! [/] ");
                    con.Close();
                    return 0;
                }
                SqlCommand cmdd = new SqlCommand($"Delete From Books Where BookID=@iddb", con);
                cmdd.Parameters.AddWithValue("@iddb", iddb);
                cmdd.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Book Details Deleted Successfully  [/] ");
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Deleting Book: {ex.Message} [/] ");
                return 0;
            }
        }
        public int AddStudent()
        {
            try
            {
                con.Open();
                SqlCommand cmdis = new SqlCommand($"Insert into Students Values(@SR,@SN,@SE)", con);
                AnsiConsole.MarkupLine($"[Blue]Enter the Student Details To Add  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student RollNo:  [/] ");
                int roli = Convert.ToInt16(Console.ReadLine());
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student Name:  [/] ");
                string nami = Console.ReadLine();
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student Email:  [/] ");
                string emai = Console.ReadLine();
                cmdis.Parameters.AddWithValue("@SR", roli);
                cmdis.Parameters.AddWithValue("@SN", nami);
                cmdis.Parameters.AddWithValue("@SE", emai);
                cmdis.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Student Details saved successfully  [/] ");
                con.Close();
                return 1;
            }
             catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Adding Student: {ex.Message} [/] ");
                return 0;
            }
        }
        public int EditStudent()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the Student Details To Edit  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student ID to Edit :  [/] ");
                int stuid = Convert.ToInt16(Console.ReadLine());
                SqlCommand checkCmd3 = new SqlCommand("Select Count(*) From Students Where StudentID = @SID", con);
                checkCmd3.Parameters.AddWithValue("@SID", stuid);
                int StudentCount = (int)checkCmd3.ExecuteScalar();
                if (StudentCount == 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Student ID not found !   [/] ");
                    con.Close();
                    return 0;
                }
                SqlCommand cmdus = new SqlCommand($"Update Students Set  StudentRollno=@SR, StudentName=@SN, StudentEmail=@SE Where StudentID=@SID", con);
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student RollNo:  [/] ");
                int rolu = Convert.ToInt16(Console.ReadLine());
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student Name:  [/] ");
                string namu = Console.ReadLine();
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student Email:  [/] ");
                string emau = Console.ReadLine();
                cmdus.Parameters.AddWithValue("@SID", stuid);
                cmdus.Parameters.AddWithValue("@SR", rolu);
                cmdus.Parameters.AddWithValue("@SN", namu);
                cmdus.Parameters.AddWithValue("@SE", emau);
                cmdus.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Student Details Edited successfully [/] ");
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Editing Student: {ex.Message} [/] ");
                return 0;
            }
        }
        public int DeleteStudent()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the Student Details To Delete  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student ID to Delete :  [/] ");
                int stuidd = Convert.ToInt16(Console.ReadLine());

                SqlCommand checkCmd4 = new SqlCommand("Select Count(*) From Students Where StudentID = @SID", con);
                checkCmd4.Parameters.AddWithValue("@SID", stuidd);
                int StudentCount = (int)checkCmd4.ExecuteScalar();
                if (StudentCount == 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Student RollNo not found ! [/] ");
                    con.Close();
                    return 0;
                }
                SqlCommand cmsd = new SqlCommand($"Delete From Students Where StudentID=@SID", con);
                cmsd.Parameters.AddWithValue("@SID", stuidd);
                cmsd.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Student Details Deleted successfully [/] ");
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Deleting Student: {ex.Message} [/] ");
                return 0;
            }
        }
        public void IssueBook()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the  Details To Issue Book  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student ID:  [/] ");
                int stuID = Convert.ToInt32(Console.ReadLine());
                SqlCommand checkCmd5 = new SqlCommand("Select Count(*) From Students Where StudentID = @SID", con);
                checkCmd5.Parameters.AddWithValue("@SID", stuID);
                int studentCount = (int)checkCmd5.ExecuteScalar();
                if (studentCount == 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Student RollNo not found !  [/] ");
                    con.Close();
                    return;
                }
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book ID to issue:   [/] ");
                int bookID = Convert.ToInt32(Console.ReadLine());
                SqlCommand checkcmd6 = new SqlCommand("Select Count(*) From Books Where BookID = @BookID AND BookQuantity > 0", con);
                checkcmd6.Parameters.AddWithValue("@BookID", bookID);
                int bookCount = (int)checkcmd6.ExecuteScalar();
                if (bookCount == 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Book not found or not available ![/] ");
                    con.Close();
                    return;
                }
   
                SqlCommand checkCmd7 = new SqlCommand("SELECT COUNT(*) FROM Management WHERE StudentID = @SID AND BookID = @BookID", con);
                checkCmd7.Parameters.AddWithValue("@SID", stuID);
                checkCmd7.Parameters.AddWithValue("@BookID", bookID);
                int issuedBookCount = (int)checkCmd7.ExecuteScalar();
                if (issuedBookCount > 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Book is already issued to the same student![/]");
                    con.Close();
                    return;
                }
                SqlCommand cmdii = new SqlCommand("Insert Into Management (StudentID, BookID, IssuedDate) Values (@SID, @BookID, GETDATE())", con);
                cmdii.Parameters.AddWithValue("@SID", stuID);
                cmdii.Parameters.AddWithValue("@BookID", bookID);
                cmdii.ExecuteNonQuery();
                SqlCommand upQuan = new SqlCommand("Update Books Set BookQuantity = BookQuantity - 1 Where BookID = @BookID", con);
                upQuan.Parameters.AddWithValue("@BookID", bookID);
                upQuan.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Book Issused Successfully:  [/] ");
                con.Close();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Adding Books: {ex.Message} [/] ");
            }
        }
        public void ReturnBook()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the  Details To Return Book  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student ID:  [/] ");
                int stuID = Convert.ToInt32(Console.ReadLine());
                AnsiConsole.MarkupLine($"[Yellow]Enter the Book ID:  [/] ");
                int bookID = Convert.ToInt32(Console.ReadLine());
                SqlCommand checkcmd7 = new SqlCommand("Select COUNT(*) From Management Where StudentID = @SID AND BookID = @BID ", con);
                checkcmd7.Parameters.AddWithValue("@SID", stuID);
                checkcmd7.Parameters.AddWithValue("@BID", bookID);
                int IssCount = (int)checkcmd7.ExecuteScalar();
                if (IssCount == 0)
                {
                    AnsiConsole.MarkupLine($"[Red]Issue ID not Found Or Book already returns ! [/] ");
                    con.Close();
                    return;
                }
                SqlCommand cmdir = new SqlCommand("Update Management Set ReturnDate = GETDATE() Where BookID = @BID", con);
                cmdir.Parameters.AddWithValue("@BID", bookID);
                cmdir.ExecuteNonQuery();
                SqlCommand upQuan = new SqlCommand("Update Books Set BookQuantity = BookQuantity + 1 Where BookID = @BID", con);
                upQuan.Parameters.AddWithValue("@BID", bookID);
                upQuan.ExecuteNonQuery();
                AnsiConsole.MarkupLine($"[Green]Book Returned Successfully:  [/] ");
                con.Close();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Returning Books: {ex.Message} [/] ");
            }
        }
        public void SearchBooks()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the  Details To Search Book  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Author Name to Search the Book: [/] ");
                string SW = Console.ReadLine();
                SqlCommand cmdb = new SqlCommand("Select * From Books Where BookAuthor = @Key", con);
                cmdb.Parameters.AddWithValue("@Key", SW);
                SqlDataReader rd = cmdb.ExecuteReader();
                if (rd.HasRows)
                {
                    AnsiConsole.MarkupLine($"[Yellow]Search Results for Book Details as:[/] ");
                    while (rd.Read())
                    {
                        AnsiConsole.MarkupLine($"[Green]Book ID: {rd["BookID"]} [/] ");
                        AnsiConsole.MarkupLine($"[Green]Book Title: {rd["BookTitle"]} [/] ");
                        AnsiConsole.MarkupLine($"[Green]Book Author: {rd["BookAuthor"]} [/] ");
                        AnsiConsole.MarkupLine($"[Green]Book Quantity: {rd["BookQuantity"]} [/] ");
                        Console.WriteLine();
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine($"[Red]No books found with given Author! [/] ");
                }
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Searching Books: {ex.Message} [/] ");
            }
        }
        public void SearchStudent()
        {
            try
            {
                con.Open();
                AnsiConsole.MarkupLine($"[Blue]Enter the  Details To Search Student  [/] ");
                AnsiConsole.MarkupLine($"[Yellow]Enter the Student ID to Search :  [/] ");
                int stuID = Convert.ToInt32(Console.ReadLine());
                SqlCommand cmds = new SqlCommand("Select * From Students Where StudentID = @SID", con);
                cmds.Parameters.AddWithValue("@SID", stuID);
                SqlDataReader rd2 = cmds.ExecuteReader();
                if (rd2.HasRows)
                {
                    AnsiConsole.MarkupLine($"[Yellow]Search Results for Student Details: [/] ");
                    while (rd2.Read())
                    {
                        AnsiConsole.MarkupLine($"[Blue]Student ID: {rd2["StudentID"]} [/] ");
                        AnsiConsole.MarkupLine($"[Blue]Student Roll No: {rd2["StudentRollno"]} [/] ");
                        AnsiConsole.MarkupLine($"[Blue]Student Name: {rd2["StudentName"]} [/] ");
                        AnsiConsole.MarkupLine($"[Blue]Student Email: {rd2["StudentEmail"]} [/] ");
                        Console.WriteLine();
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine($"[Red]No student found with the given Student ID [/] ");
                }
                rd2.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Searching Students: {ex.Message} [/] ");
            }
        }
        public void StudentsWithBooks()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Count(*) From Management Where ReturnDate IS NULL", con);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    AnsiConsole.MarkupLine($"[Green]Number of Students with Books: {count} [/] ");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[Red]No students currently have books ! [/] ");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[Red]An Error Occurred While Searching Students With Books: {ex.Message} [/] ");
            }
        }
    }
    internal class Program
    {     
        static void Main(string[] args)
        {
            Library l = new Library();
            AnsiConsole.Write(new FigletText("LIBRARY MANAGEMENT APPLICATION ").Centered().Color(Color.Blue));
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            AnsiConsole.MarkupLine($"[Yellow]Enter the Username: [/] ");
            string username = Console.ReadLine();
            AnsiConsole.MarkupLine($"[Yellow]Enter the Password: [/] ");
            string password = Console.ReadLine();
            if (username == "User1234" && password == "Pass@1234")
            {
                AnsiConsole.MarkupLine($"[Green]Login Successfull [/] ");
                Console.WriteLine();
                string ret = "y";
                int choice;
                do
                {
                    try
                    {
                        AnsiConsole.MarkupLine($"[Yellow] ----------------------Main Menu------------------- [/] ");
                        Console.WriteLine();
                        AnsiConsole.MarkupLine($"[Blue] 1. Add Book Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 2. Edit Book Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 3. Delete Book Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 4. Add Student Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 5. Edit Student Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 6. Delete Student Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 7. Issue Book to Student [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 8. Return Book from Student [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 9. Search Book Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 10.Search Student Details [/] ");
                        AnsiConsole.MarkupLine($"[Blue] 11.How many students have books right now? [/] ");
                        Console.WriteLine();
                        AnsiConsole.MarkupLine($"[Yellow]Enter your choice: [/] ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                {
                                    l.AddBook();
                                    break;
                                }
                            case 2:
                                {
                                    l.EditBook();
                                    break;
                                }
                            case 3:
                                {
                                    l.DeleteBook();
                                    break;
                                }
                            case 4:
                                {
                                    l.AddStudent();
                                    break;
                                }
                            case 5:
                                {
                                    l.EditStudent();
                                    break;
                                }
                            case 6:
                                {
                                    l.DeleteStudent();
                                    break;
                                }
                            case 7:
                                {
                                    l.IssueBook();
                                    break;
                                }
                            case 8:
                                {
                                    l.ReturnBook();
                                    break;
                                }
                            case 9:
                                {
                                    l.SearchBooks();
                                    break;
                                }
                            case 10:
                                {
                                    l.SearchStudent();
                                    break;
                                }
                            case 11:
                                {
                                    l.StudentsWithBooks();
                                    break;
                                }
                            default:
                                {
                                    AnsiConsole.MarkupLine($"[Red]Invalid choice! Please try again ! [/] ");
                                    break;
                                }
                        }
                    }
                    catch (FormatException)
                    {
                        AnsiConsole.MarkupLine($"[Red]Entered Values Will be only in Numbers [/]");
                    }
                    Console.WriteLine();
                    AnsiConsole.MarkupLine($"[Yellow]Do you wish to continue? (y/n)  [/] ");
                    ret = Console.ReadLine();
                } while (ret.ToLower() == "y");           
            }
            else
            {
                AnsiConsole.MarkupLine($"[Red]INVALID USERNAME OR PASSWORD ! PLEASE TRY AGAIN [/] ");
            }
        }
    }
}