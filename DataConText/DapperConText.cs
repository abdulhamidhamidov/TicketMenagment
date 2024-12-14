using Npgsql;

namespace WebApiDapper.DataConText;

public class DapperConText
{
    private readonly string connection = "Server=localhost;Port=5432;Database=TicketMenagmentDb;Username=postgres;password=12345";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connection);
    }
}