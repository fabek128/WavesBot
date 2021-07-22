using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorSite.Services
{
    public class AccountService : IAccountService
    {
        ILocalStorageService _localStorageService;
        public AccountService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        List<int> randomList = new List<int>();
        string[] words = new string[] {
            "apple", "mingo", "paraguay", "mission", "okey", "diego",
            "maradona", "santa", "code", "hyper", "mac", "charlote",
            "group", "signals", "latino", "down", "upside", "killer",
            "game", "commodore", "spectrum", "original", "great", "love",
            "images", "nonstop", "cents", "classic", "dreamer", "pinacle",
            "summer", "winter", "must", "have", "xinobi", "xiaomi",
            "vibe", "valve", "only", "miles", "cold", "cool",
            "colour", "bad", "good", "our", "dream", "goback",
            "beyond", "bloom", "sun", "settle", "dapple", "bit",
            "mode", "omd", "floor", "all", "wego", "informer",
            "power", "snap", "stereo", "groove", "get", "step",
            "any", "another", "world", "mars", "techno", "tronic",
            "tom", "jerry", "night", "buck", "roggers", "counter",
            "string", "commando", "strike", "ship", "bestof", "hit",
            "elena", "tipo", "doctor", "mister", "while", "then",
            "millenium", "aprende", "hijos", "car", "sister", "superman"
        };

        private int getRndIndex(int length)
        {
            Random rnd = new Random();
            while (true)
            {
                var n = rnd.Next(0, length);
                if (!randomList.Contains(n))
                {
                    randomList.Add(n);
                    return n;
                }
            }
            throw new Exception();
        }

        public async Task<string> GenerateRandomSeed()
        {
            var seed = new string[12];
            for (var i = 0; i < 12; i++)
            {
                seed[i] = words[getRndIndex(words.Length)];
            }
            return await Task.FromResult<string>(string.Join(" ", seed));
        }

        public async Task<string> GetSeed()
        {
            return await _localStorageService.GetItem<string>("seed");
        }
    }
}