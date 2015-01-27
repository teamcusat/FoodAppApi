
namespace FoodApp.Core
{
    /// <summary>
    /// The geographic helper
    /// </summary>
    public static class GeographicHelper
    {
        /// <summary>
        /// To convert the meters to degree 
        /// </summary>
        /// <param name="meter"></param>
        /// <returns></returns>
        public static double ConvertToDegrees(double? meter)
        {
            var mtr = meter ?? 0;
            var fact = 11000; //Approximate value
            return mtr / fact;
        }
    }
}
