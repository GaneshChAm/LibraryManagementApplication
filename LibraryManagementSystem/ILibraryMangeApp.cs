using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public interface IlibraryMangeApp
    {
        int AddBook();
        int EditBook();
        int DeleteBook();

        int AddStudent();
        int EditStudent();
        int DeleteStudent();     
    }
}
