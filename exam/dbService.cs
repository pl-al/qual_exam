namespace exam;
using Models;

public class dbService
{
    private static PostgresContext db;

    public static PostgresContext GetContext()
    {
        if (db == null)
            db = new PostgresContext();
        return db;
    }
}