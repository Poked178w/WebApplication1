using MvcApp.Models;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace MvcApp.Models
{
    public static class Repository
    {
        private static List<Player> responses =
        new List<Player>();
        public static IEnumerable<Player> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(Player response)
        {
            responses.Add(response);
        }
    }
}
