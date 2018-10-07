using System;

namespace PowerLinks
{
    public class Formulas
    {
        /// <summary>
        /// Calculates power between link station and device
        /// </summary>
        /// <param name="linkStation">Linkstation element</param>
        /// <param name="distance">Distance between link station and device</param>
        /// <returns>Returns power</returns>
        public double CalcPower(Device device, LinkStation linkStation)
        {
            double distance = CalcDistance(device,linkStation);

            if (linkStation.reach > distance)
                return Math.Round(Math.Pow(linkStation.reach - distance, 2), 2);
            else
                return 0;
        }

        /// <summary>
        /// Calculates distance between device and link station in 2D space
        /// </summary>
        /// <param name="device">Device element</param>
        /// <param name="linkStation">Link Station element</param>
        /// <returns>Returns distance between device and link station in 2D space</returns>
        private double CalcDistance(Device device, LinkStation linkStation)
        {
            double xDistance = device.posX - linkStation.posX;
            double yDistance = device.posY - linkStation.posY;

            return Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        }

        /// <summary>
        /// Prints out result string
        /// </summary>
        /// <param name="device">Device</param>
        /// <param name="linkstation">Best Link Station</param>
        /// <returns>Returns result string</returns>
        public string PrintResult(Device device, LinkStation linkStation)
        {
            if (linkStation.power == 0)
                return string.Format("No Link Station within Reach for Point {0}, {1}", device.posX, device.posY);
            else
                return string.Format("Best Link Station for Point {0}, {1} is {2}, {3} with Power {4}", device.posX, device.posY, linkStation.posX, linkStation.posY, linkStation.power);
        }
    }
}
