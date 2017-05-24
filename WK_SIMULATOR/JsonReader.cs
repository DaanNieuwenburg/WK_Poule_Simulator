using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using WK_SIMULATOR.Model;

namespace WK_SIMULATOR
{
    public class JsonReader
    {
        /// <summary>
        /// Read all players of all teams from a JSON file
        /// </summary>
        /// <returns>Returns a list of all players</returns>
        public List<Player> Read_Players()
        {
            List<Player> Playerlist = new List<Player>();
            // Read the Players from a JSON file and put them in a list
            using (StreamReader reader = new StreamReader(@"Files\Teamplayers2.json"))
            {
                string json = reader.ReadToEnd();
                Playerlist = JsonConvert.DeserializeObject<List<Player>>(json).ToList<Player>();
            }
            return Playerlist;
        }
    }
}


