using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFace.Helpers;
using MyFace.Models.Database;

namespace MyFace.Data
{
    public static class SampleUsers
    {
        public static int NumberOfUsers = 100;
        private static HashHelper _hashHelper = new HashHelper();
        
        private static IList<IList<string>> _data = new List<IList<string>>
        {
            new List<string> { "Kania", "Placido", "kplacido0", "kplacido0@qq.com",  "TimeAndTide" },
            new List<string> { "Scotty", "Gariff", "sgariff1", "sgariff1@biblegateway.com",  "TimeAndTide" },
            new List<string> { "Colly", "Burgiss", "cburgiss2", "cburgiss2@amazon.co.uk",  "TimeAndTide" },
            new List<string> { "Barnie", "Percival", "bpercival3", "bpercival3@cmu.edu",  "TimeAndTide" },
            new List<string> { "Brandon", "Narraway", "bnarraway4", "bnarraway4@trellian.com",  "TimeAndTide" },
            new List<string> { "Carlos", "Sakins", "csakins5", "csakins5@spiegel.de",  "TimeAndTide" },
            new List<string> { "Zeke", "Barkworth", "zbarkworth6", "zbarkworth6@symantec.com",  "TimeAndTide" },
            new List<string> { "Henrietta", "Verick", "hverick7", "hverick7@adobe.com",  "TimeAndTide" },
            new List<string> { "Maxine", "Lovett", "mlovett8", "mlovett8@mac.com",  "TimeAndTide" },
            new List<string> { "Adorne", "Smyth", "asmyth9", "asmyth9@nyu.edu",  "TimeAndTide" },
            new List<string> { "Roslyn", "O' Scallan", "roscallana", "roscallana@marriott.com",  "TimeAndTide" },
            new List<string> { "Kalindi", "Bevington", "kbevingtonb", "kbevingtonb@wired.com",  "TimeAndTide" },
            new List<string> { "Silva", "Cow", "scowc", "scowc@yellowbook.com",  "TimeAndTide" },
            new List<string> { "Gnni", "Northage", "gnorthaged", "gnorthaged@lulu.com",  "TimeAndTide" },
            new List<string> { "Jobi", "Balsom", "jbalsome", "jbalsome@ox.ac.uk",  "TimeAndTide" },
            new List<string> { "Laurice", "Galgey", "lgalgeyf", "lgalgeyf@usa.gov",  "TimeAndTide" },
            new List<string> { "Orsola", "Laurant", "olaurantg", "olaurantg@reverbnation.com",  "TimeAndTide" },
            new List<string> { "Dante", "Mabley", "dmableyh", "dmableyh@scientificamerican.com",  "TimeAndTide" },
            new List<string> { "Shantee", "Guillond", "sguillondi", "sguillondi@gravatar.com",  "TimeAndTide" },
            new List<string> { "Mendy", "Djuricic", "mdjuricicj", "mdjuricicj@tuttocitta.it",  "TimeAndTide" },
            new List<string> { "Ralph", "Adamovicz", "radamoviczk", "radamoviczk@salon.com",  "TimeAndTide" },
            new List<string> { "Zsa zsa", "Goodacre", "zgoodacrel", "zgoodacrel@histats.com",  "TimeAndTide" },
            new List<string> { "Fleurette", "Blow", "fblowm", "fblowm@who.int",  "TimeAndTide" },
            new List<string> { "Zelda", "Pritchett", "zpritchettn", "zpritchettn@wordpress.org",  "TimeAndTide" },
            new List<string> { "Kaitlyn", "Filshin", "kfilshino", "kfilshino@so-net.ne.jp",  "TimeAndTide" },
            new List<string> { "Aube", "Goneau", "agoneaup", "agoneaup@barnesandnoble.com",  "TimeAndTide" },
            new List<string> { "Natala", "Mackrill", "nmackrillq", "nmackrillq@google.es",  "TimeAndTide" },
            new List<string> { "Ev", "Wadly", "ewadlyr", "ewadlyr@adobe.com",  "TimeAndTide" },
            new List<string> { "Aurora", "Feedham", "afeedhams", "afeedhams@house.gov",  "TimeAndTide" },
            new List<string> { "Farly", "Chestney", "fchestneyt", "fchestneyt@usda.gov",  "TimeAndTide" },
            new List<string> { "Chico", "Guilloux", "cguillouxu", "cguillouxu@senate.gov",  "TimeAndTide" },
            new List<string> { "Julianna", "Huckstepp", "jhucksteppv", "jhucksteppv@ycombinator.com",  "TimeAndTide" },
            new List<string> { "Bev", "Sancto", "bsanctow", "bsanctow@spiegel.de",  "TimeAndTide" },
            new List<string> { "Shara", "Jeeves", "sjeevesx", "sjeevesx@behance.net",  "TimeAndTide" },
            new List<string> { "Legra", "Jereatt", "ljereatty", "ljereatty@prnewswire.com",  "TimeAndTide" },
            new List<string> { "Katey", "Ternouth", "kternouthz", "kternouthz@webmd.com",  "TimeAndTide" },
            new List<string> { "Val", "McMenamin", "vmcmenamin10", "vmcmenamin10@noaa.gov",  "TimeAndTide" },
            new List<string> { "Shannan", "Greenhalf", "sgreenhalf11", "sgreenhalf11@gravatar.com",  "TimeAndTide" },
            new List<string> { "Sterling", "Fellgate", "sfellgate12", "sfellgate12@surveymonkey.com",  "TimeAndTide" },
            new List<string> { "Brina", "Dickens", "bdickens13", "bdickens13@zimbio.com",  "TimeAndTide" },
            new List<string> { "Boniface", "McKaile", "bmckaile14", "bmckaile14@jalbum.net",  "TimeAndTide" },
            new List<string> { "Vincenty", "Aishford", "vaishford15", "vaishford15@wordpress.org",  "TimeAndTide" },
            new List<string> { "Kathye", "Gauford", "kgauford16", "kgauford16@xrea.com",  "TimeAndTide" },
            new List<string> { "Chico", "Seelbach", "cseelbach17", "cseelbach17@over-blog.com",  "TimeAndTide" },
            new List<string> { "Enoch", "Winsper", "ewinsper18", "ewinsper18@devhub.com",  "TimeAndTide" },
            new List<string> { "Brandie", "Welds", "bwelds19", "bwelds19@chicagotribune.com",  "TimeAndTide" },
            new List<string> { "Bethanne", "Kerin", "bkerin1a", "bkerin1a@acquirethisname.com",  "TimeAndTide" },
            new List<string> { "Margo", "Tompkins", "mtompkins1b", "mtompkins1b@mayoclinic.com",  "TimeAndTide" },
            new List<string> { "Allie", "Clever", "aclever1c", "aclever1c@slideshare.net",  "TimeAndTide" },
            new List<string> { "North", "Denny", "ndenny1d", "ndenny1d@simplemachines.org",  "TimeAndTide" },
            new List<string> { "Ted", "Scorah", "tscorah1e", "tscorah1e@devhub.com",  "TimeAndTide" },
            new List<string> { "Leone", "McGow", "lmcgow1f", "lmcgow1f@unblog.fr",  "TimeAndTide" },
            new List<string> { "Abbie", "Jannasch", "ajannasch1g", "ajannasch1g@sakura.ne.jp",  "TimeAndTide" },
            new List<string> { "Marika", "Dommett", "mdommett1h", "mdommett1h@infoseek.co.jp",  "TimeAndTide" },
            new List<string> { "Edith", "Norcop", "enorcop1i", "enorcop1i@behance.net",  "TimeAndTide" },
            new List<string> { "Ernest", "Baline", "ebaline1j", "ebaline1j@amazon.co.uk",  "TimeAndTide" },
            new List<string> { "Rowen", "Dorcey", "rdorcey1k", "rdorcey1k@gravatar.com",  "TimeAndTide" },
            new List<string> { "Pasquale", "Surplice", "psurplice1l", "psurplice1l@paypal.com",  "TimeAndTide" },
            new List<string> { "Tim", "Dyott", "tdyott1m", "tdyott1m@yellowbook.com",  "TimeAndTide" },
            new List<string> { "Tedd", "Connachan", "tconnachan1n", "tconnachan1n@so-net.ne.jp",  "TimeAndTide" },
            new List<string> { "Jacquetta", "McClelland", "jmcclelland1o", "jmcclelland1o@nifty.com",  "TimeAndTide" },
            new List<string> { "Nelli", "Maund", "nmaund1p", "nmaund1p@myspace.com",  "TimeAndTide" },
            new List<string> { "Morie", "Anselmi", "manselmi1q", "manselmi1q@nytimes.com",  "TimeAndTide" },
            new List<string> { "Gabie", "Antoniazzi", "gantoniazzi1r", "gantoniazzi1r@dailymail.co.uk",  "TimeAndTide" },
            new List<string> { "Menard", "Engelbrecht", "mengelbrecht1s", "mengelbrecht1s@over-blog.com",  "TimeAndTide" },
            new List<string> { "Mike", "Tommasetti", "mtommasetti1t", "mtommasetti1t@bluehost.com",  "TimeAndTide" },
            new List<string> { "Eldin", "Fredy", "efredy1u", "efredy1u@mozilla.com",  "TimeAndTide" },
            new List<string> { "Pris", "McCowen", "pmccowen1v", "pmccowen1v@jalbum.net",  "TimeAndTide" },
            new List<string> { "Joey", "Dossettor", "jdossettor1w", "jdossettor1w@webnode.com",  "TimeAndTide" },
            new List<string> { "Daisey", "Ogdahl", "dogdahl1x", "dogdahl1x@nyu.edu",  "TimeAndTide" },
            new List<string> { "Melanie", "Searle", "msearle1y", "msearle1y@loc.gov",  "TimeAndTide" },
            new List<string> { "Beatrix", "MacLise", "bmaclise1z", "bmaclise1z@hugedomains.com",  "TimeAndTide" },
            new List<string> { "Missy", "Hillitt", "mhillitt20", "mhillitt20@multiply.com",  "TimeAndTide" },
            new List<string> { "Belinda", "Tumielli", "btumielli21", "btumielli21@php.net",  "TimeAndTide" },
            new List<string> { "Raynor", "Dupey", "rdupey22", "rdupey22@fc2.com",  "TimeAndTide" },
            new List<string> { "Inigo", "Heineke", "iheineke23", "iheineke23@ihg.com",  "TimeAndTide" },
            new List<string> { "Ilaire", "Angric", "iangric24", "iangric24@apache.org",  "TimeAndTide" },
            new List<string> { "Estel", "Steljes", "esteljes25", "esteljes25@livejournal.com",  "TimeAndTide" },
            new List<string> { "Lyell", "Ashard", "lashard26", "lashard26@umn.edu",  "TimeAndTide" },
            new List<string> { "Darren", "Devons", "ddevons27", "ddevons27@economist.com",  "TimeAndTide" },
            new List<string> { "Warden", "Undrell", "wundrell28", "wundrell28@mozilla.org",  "TimeAndTide" },
            new List<string> { "Iris", "Langworthy", "ilangworthy29", "ilangworthy29@timesonline.co.uk",  "TimeAndTide" },
            new List<string> { "Marten", "Minards", "mminards2a", "mminards2a@statcounter.com",  "TimeAndTide" },
            new List<string> { "Kerry", "Bennion", "kbennion2b", "kbennion2b@spotify.com",  "TimeAndTide" },
            new List<string> { "Olivette", "Norridge", "onorridge2c", "onorridge2c@cpanel.net",  "TimeAndTide" },
            new List<string> { "Rosalinde", "Traske", "rtraske2d", "rtraske2d@bbc.co.uk",  "TimeAndTide" },
            new List<string> { "Gaultiero", "McCard", "gmccard2e", "gmccard2e@utexas.edu",  "TimeAndTide" },
            new List<string> { "Zonnya", "Capstaff", "zcapstaff2f", "zcapstaff2f@theatlantic.com",  "TimeAndTide" },
            new List<string> { "Ingelbert", "Sleford", "isleford2g", "isleford2g@qq.com",  "TimeAndTide" },
            new List<string> { "Nicol", "Nary", "nnary2h", "nnary2h@google.com.hk",  "TimeAndTide" },
            new List<string> { "Jasun", "Lukianov", "jlukianov2i", "jlukianov2i@blogs.com",  "TimeAndTide" },
            new List<string> { "Alison", "Durkin", "adurkin2j", "adurkin2j@sitemeter.com",  "TimeAndTide" },
            new List<string> { "Claudius", "Coronas", "ccoronas2k", "ccoronas2k@tamu.edu",  "TimeAndTide" },
            new List<string> { "Jakie", "Keener", "jkeener2l", "jkeener2l@princeton.edu",  "TimeAndTide" },
            new List<string> { "Gilbertine", "Wynett", "gwynett2m", "gwynett2m@epa.gov",  "TimeAndTide" },
            new List<string> { "Syd", "Cordelle", "scordelle2n", "scordelle2n@blogger.com",  "TimeAndTide" },
            new List<string> { "Stafford", "Deport", "sdeport2o", "sdeport2o@wix.com",  "TimeAndTide" },
            new List<string> { "Zacharie", "Perchard", "zperchard2p", "zperchard2p@qq.com",  "TimeAndTide" },
            new List<string> { "Jane", "Iceton", "jiceton2q", "jiceton2q@lulu.com",  "TimeAndTide" },
            new List<string> { "Marjy", "Beadell", "mbeadell2r", "mbeadell2r@delicious.com",  "TimeAndTide" }
        };
        
        public static IEnumerable<User> GetUsers()
        {
            return Enumerable.Range(0, NumberOfUsers).Select(CreateRandomUser);
        }

        private static User CreateRandomUser(int index)
        {
            byte[] generatedSalt = _hashHelper.GenerateSalt();
            return new User
            {
                FirstName = _data[index][0],
                LastName = _data[index][1],
                Username = _data[index][2],
                Email = _data[index][3],
                ProfileImageUrl = ImageGenerator.GetProfileImage(_data[index][2]),
                CoverImageUrl = ImageGenerator.GetCoverImage(index),
                Salt = generatedSalt,
                HashedPassword = _hashHelper.GenerateHash(_data[index][4], generatedSalt)
            };
        }
    }
}