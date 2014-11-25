using System.Configuration;
using System.Data.SqlClient;

namespace FoodApp.Data
{
    /// <summary>
    ///     The repository base.
    /// </summary>
    public class RepositoryBase
    {

        /// <summary>
        ///     Gets the connection string.
        /// </summary>
        protected string ConnectionString
        {
            get
            {
                return "Data Source=tcp:h8hee7ff7g.database.windows.net,1433;Initial Catalog=FoodApp;User Id=jithindraj@h8hee7ff7g;Password=Teamcusat_123";//ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        /// <summary>
        ///     Gets the connection.
        /// </summary>
        protected SqlConnection Connection
        {
            get
            {
                return new SqlConnection(this.ConnectionString);
            }
        }
    }
}
