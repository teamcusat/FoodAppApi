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
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
