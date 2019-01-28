using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevelopmentTest.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
