using ExampleMvcProject.MVC.Entities;

namespace ExampleMvcProject.MVC.Service
{
    public class BookstoreSeeder
    {
        private readonly BookstoreDbContext _dbContext;
        public BookstoreSeeder(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.books.Any())
                {
                    var books = GetBooks();
                    _dbContext.books.AddRange(books);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.audiobooks.Any())
                {
                    var audiobooks = GetAudiobooks();
                    _dbContext.audiobooks.AddRange(audiobooks);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.musics.Any())
                {
                    var musics = GetMusics();
                    _dbContext.musics.AddRange(musics);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.films.Any())
                {
                    var films = GetFilms();
                    _dbContext.films.AddRange(films);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Title = "Wiedźmin: Ostatnie Życzenie",
                    Description = "Zbiór opowiadań o Geralcie z Rivii, wiedźminie zajmującym się zabijaniem potworów. " +
                    "Pełen moralnych dylematów i przygód w świecie magii i mitologii.",
                    Author = "Andrzej Sapkowski",
                    Quantity = 10,
                    ImagePath = "/images/books/wiedzmin-ostatnie-zyczenie.jpg"
                },
                new Book()
                {
                    Title = "Alicja w Krainie Czarów",
                    Description = "Alicja wpada do magicznej krainy, gdzie spotyka dziwne postacie i przeżywa surrealistyczne przygody. " +
                    "Klasyczna opowieść o świecie pełnym fantazji.",
                    Author = "Lewis Carroll",
                    Quantity = 12,
                    ImagePath = "/images/books/alicja-w-krainie-czarow.jpg"
                },
                new Book()
                {
                    Title = "Metro 2033",
                    Description = "Po apokalipsie mieszkańcy Moskwy żyją w metrze. " +
                    "Młody Artem wyrusza na niebezpieczną misję przez ciemne tunele, pełne mutantów i zagrożeń.",
                    Author = "Dmitrij Głuchowski",
                    Quantity = 12,
                    ImagePath = "/images/books/metro-2033.jpg"
                },
                new Book { Title = "1984", Description = "Opowieść o świecie totalitarnej kontroli i manipulacji.", Author = "George Orwell", ImagePath = "/images/books/default-image.jpg", Quantity = 15 },
                new Book { Title = "Zbrodnia i kara", Description = "Młody student stawia czoła moralnym konsekwencjom morderstwa.", Author = "Fiodor Dostojewski", ImagePath = "/images/books/default-image.jpg", Quantity = 12 },
                new Book { Title = "Wielki Gatsby", Description = "Historia tajemniczego milionera i jego nieszczęśliwej miłości.", Author = "F. Scott Fitzgerald", ImagePath = "/images/books/default-image.jpg", Quantity = 8 },
                new Book { Title = "Lśnienie", Description = "Piszący mężczyzna popada w szaleństwo w odizolowanym hotelu.", Author = "Stephen King", ImagePath = "/images/books/default-image.jpg", Quantity = 10 },
                new Book { Title = "Duma i uprzedzenie", Description = "Kobieca miłość i duma krzyżują drogi w angielskim społeczeństwie.", Author = "Jane Austen", ImagePath = "/images/books/default-image.jpg", Quantity = 18 },
                new Book { Title = "Harry Potter i Kamień Filozoficzny", Description = "Chłopiec odkrywa, że jest czarodziejem i rozpoczyna edukację w Hogwarcie.", Author = "J.K. Rowling", ImagePath = "/images/books/default-image.jpg", Quantity = 20 },
                new Book { Title = "Władca Pierścieni: Drużyna Pierścienia", Description = "Hobbit Frodo wyrusza na misję zniszczenia potężnego pierścienia.", Author = "J.R.R. Tolkien", ImagePath = "/images/books/default-image.jpg", Quantity = 25 },
                new Book { Title = "Przeminęło z wiatrem", Description = "Epicka historia miłości i przetrwania w czasie wojny secesyjnej.", Author = "Margaret Mitchell", ImagePath = "/images/books/default-image.jpg", Quantity = 10 },
                new Book { Title = "Mistrz i Małgorzata", Description = "Diabeł pojawia się w Moskwie i zaczyna bawić się ludzkimi losami.", Author = "Michaił Bułhakow", ImagePath = "/images/books/default-image.jpg", Quantity = 9 },
                new Book { Title = "Hobbit", Description = "Bilbo Baggins wyrusza na wyprawę z krasnoludami, by odzyskać skarb.", Author = "J.R.R. Tolkien", ImagePath = "/images/books/default-image.jpg", Quantity = 13 }
            };

            return books;
        }

        private IEnumerable<Audiobook> GetAudiobooks()
        {
            List<Audiobook> audiobooks = new List<Audiobook>()
            {
                new Audiobook()
                {
                    Title = "Krew elfów",
                    Description = "Pierwsza powieść z głównego cyklu, w której Geralt zostaje opiekunem Ciri, " +
                    "księżniczki, której przeznaczenie jest ściśle związane z przyszłością.",
                    Quantity = 12,
                    Author = "Andrzej Sapkowski",
                    ImagePath = "/images/audiobooks/w1.jpg"
                },
                new Audiobook()
                {
                    Title = "Czas pogardy",
                    Description = "Kontynuuje wątki z „Krwii elfów” i opisuje dalsze losy " +
                    "Geralta i Ciri w świecie pogrążonym w chaosie wojennym.",
                    Quantity = 12,
                    Author = "Andrzej Sapkowski",
                    ImagePath = "/images/audiobooks/w2.jpg"
                },
                new Audiobook()
                {
                    Title = "Chrzest ognia",
                    Description = "Geralt, wciąż poszukujący Ciri, wyrusza w niebezpieczną podróż przez " +
                    "ogarnięty wojną świat.",
                    Quantity = 12,
                    Author = "Andrzej Sapkowski",
                    ImagePath = "/images/audiobooks/w3.jpg"
                },
                new Audiobook()
                {
                    Title = "Wieża Jaskółki",
                    Description = "Geralt i jego przyjaciele kontynuują poszukiwania Ciri, której przeznaczenie " +
                    "staje się coraz bardziej złożone.",
                    Quantity = 12,
                    Author = "Andrzej Sapkowski",
                    ImagePath = "/images/audiobooks/w4.jpg"
                },
                new Audiobook()
                {
                    Title = "Pani Jeziora",
                    Description = "Finałowa część sagi, w której wątki związane z " +
                    "Ciri i Geraltem osiągają kulminację.",
                    Quantity = 12,
                    Author = "Andrzej Sapkowski",
                    ImagePath = "/images/audiobooks/w5.jpg"
                }
            };

            return audiobooks;
        }

        private IEnumerable<Music> GetMusics()
        {
            List<Music> musicList = new List<Music>()
            {
                new Music() { Title = "Lose Yourself", Description = "Motywujący utwór Eminema o determinacji i walce.", Quantity = 15, Author = "Eminem", MusicType = "Rap", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Numb", Description = "Emocjonalny utwór Linkin Park o poczuciu zagubienia.", Quantity = 20, Author = "Linkin Park", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Smells Like Teen Spirit", Description = "Hymn grunge'u zespołu Nirvana.", Quantity = 18, Author = "Nirvana", MusicType = "Grunge", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Enter Sandman", Description = "Kultowy utwór zespołu Metallica o strachu i niepokoju.", Quantity = 22, Author = "Metallica", MusicType = "Metal", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Shape of You", Description = "Popowy hit Ed Sheerana o miłości i relacjach.", Quantity = 25, Author = "Ed Sheeran", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Billie Jean", Description = "Legendarny utwór Michaela Jacksona o skandalu.", Quantity = 30, Author = "Michael Jackson", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Thriller", Description = "Słynny utwór Michaela Jacksona z niezapomnianym teledyskiem.", Quantity = 28, Author = "Michael Jackson", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Bohemian Rhapsody", Description = "Epicka kompozycja zespołu Queen.", Quantity = 35, Author = "Queen", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "In the End", Description = "Potężny utwór Linkin Park o niepewności i stracie.", Quantity = 20, Author = "Linkin Park", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Rolling in the Deep", Description = "Emocjonalny hit Adele o zdradzie i rozczarowaniu.", Quantity = 26, Author = "Adele", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Uptown Funk", Description = "Energetyczny utwór Marka Ronsona i Bruno Marsa.", Quantity = 23, Author = "Mark Ronson ft. Bruno Mars", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Hail to the King", Description = "Potężny utwór Avenged Sevenfold z mocnym brzmieniem.", Quantity = 18, Author = "Avenged Sevenfold", MusicType = "Metal", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Sweet Child O' Mine", Description = "Romantyczny hit Guns N' Roses z niezapomnianym riffem gitarowym.", Quantity = 25, Author = "Guns N' Roses", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Bad Guy", Description = "Chwytliwy utwór Billie Eilish z nowoczesnym brzmieniem.", Quantity = 20, Author = "Billie Eilish", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Closer", Description = "Hit The Chainsmokers o skomplikowanej relacji.", Quantity = 22, Author = "The Chainsmokers ft. Halsey", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "One", Description = "Wzruszający utwór Metallica o wojnie i jej kosztach.", Quantity = 30, Author = "Metallica", MusicType = "Metal", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Sunflower", Description = "Przyjemny utwór Post Malone i Swae Lee.", Quantity = 27, Author = "Post Malone & Swae Lee", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "God's Plan", Description = "Inspirujący utwór Drake'a o przeznaczeniu i sukcesie.", Quantity = 25, Author = "Drake", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "I Love It", Description = "Energiczny utwór Kanye Westa i Lil Pumpa.", Quantity = 23, Author = "Kanye West & Lil Pump", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Old Town Road", Description = "Hit Lil Nas X, który łączy country i hip-hop.", Quantity = 30, Author = "Lil Nas X", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Numb/Encore", Description = "Kolaboracja Linkin Park i Jay-Z, łącząca rock i rap.", Quantity = 20, Author = "Linkin Park & Jay-Z", MusicType = "Rap", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Rockstar", Description = "Utwór Post Malone o luksusach i stylu życia.", Quantity = 18, Author = "Post Malone", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Killing in the Name", Description = "Antyrasistowski utwór Rage Against The Machine.", Quantity = 22, Author = "Rage Against The Machine", MusicType = "Metal", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Paranoid", Description = "Klasyczny utwór Black Sabbath o uczuciach paranoi.", Quantity = 20, Author = "Black Sabbath", MusicType = "Metal", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Zombie", Description = "Zadawany utwór The Cranberries o wojnie i przemocy.", Quantity = 26, Author = "The Cranberries", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Don't Stop Believin'", Description = "Motywacyjny utwór Journey o nadziei i wierze.", Quantity = 24, Author = "Journey", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Thunderstruck", Description = "Energetyczny utwór AC/DC, który wzbudza emocje.", Quantity = 18, Author = "AC/DC", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Teenage Dirtbag", Description = "Pop-rockowy hit Wheatus o nastoletnich problemach.", Quantity = 25, Author = "Wheatus", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Bad Romance", Description = "Harmonijny utwór Lady Gagi o miłości i pragnieniu.", Quantity = 30, Author = "Lady Gaga", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Viva La Vida", Description = "Podniosły utwór Coldplay o upadku i refleksji.", Quantity = 22, Author = "Coldplay", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Royals", Description = "Minimalistyczny hit Lorde o młodzieńczej postawie.", Quantity = 20, Author = "Lorde", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "All Star", Description = "Radosny utwór Smash Mouth o pewności siebie i radości.", Quantity = 18, Author = "Smash Mouth", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Blinding Lights", Description = "Energetyczny hit The Weeknd o miłości i tęsknocie.", Quantity = 25, Author = "The Weeknd", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Levitating", Description = "Chwytliwy utwór Dua Lipa z przyjemnym rytmem.", Quantity = 22, Author = "Dua Lipa", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Sicko Mode", Description = "Energetyczny utwór Travis Scott z dynamicznymi zmianami.", Quantity = 20, Author = "Travis Scott", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Mo Bamba", Description = "Hit Sheck Wes z mocnym beatem i energią.", Quantity = 18, Author = "Sheck Wes", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Sucker", Description = "Radosny utwór Jonas Brothers o miłości i zaangażowaniu.", Quantity = 25, Author = "Jonas Brothers", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Watermelon Sugar", Description = "Letni hit Harry'ego Stylesa o miłości i wakacjach.", Quantity = 22, Author = "Harry Styles", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Savage Love", Description = "Hit Jawsh 685 i Jasona Derulo o miłości i pragnieniu.", Quantity = 20, Author = "Jawsh 685 & Jason Derulo", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Good 4 U", Description = "Energetyczny utwór Olivia Rodrigo o zdradzie i gniewie.", Quantity = 18, Author = "Olivia Rodrigo", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Peaches", Description = "Radosny utwór Justina Biebera z przyjemnym beatem.", Quantity = 25, Author = "Justin Bieber ft. Daniel Caesar, Giveon", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Industry Baby", Description = "Energetyczny utwór Lil Nas X i Jack Harlow o sukcesie.", Quantity = 22, Author = "Lil Nas X & Jack Harlow", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Roses", Description = "Hit SAINt JHN z hipnotyzującym rytmem.", Quantity = 20, Author = "SAINt JHN", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "The Box", Description = "Chwytliwy utwór Roddy Ricch z mocnym beatem.", Quantity = 18, Author = "Roddy Ricch", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "HUMBLE.", Description = "Potężny utwór Kendricka Lamara o pokorze i sukcesie.", Quantity = 25, Author = "Kendrick Lamar", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Bad Liar", Description = "Melancholijny utwór Imagine Dragons o kłamstwie i zdradzie.", Quantity = 22, Author = "Imagine Dragons", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Believer", Description = "Motywacyjny hit Imagine Dragons o wierze w siebie.", Quantity = 20, Author = "Imagine Dragons", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "High Hopes", Description = "Inspirujący utwór Panic! At The Disco o marzeniach i aspiracjach.", Quantity = 25, Author = "Panic! At The Disco", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Shallow", Description = "Wzruszający duet Lady Gagi i Bradley'a Coopera.", Quantity = 22, Author = "Lady Gaga & Bradley Cooper", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Uptown Funk", Description = "Energetyczny hit Marka Ronsona i Bruno Marsa.", Quantity = 23, Author = "Mark Ronson ft. Bruno Mars", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Can't Stop the Feeling!", Description = "Optymistyczny utwór Justina Timberlake'a o radości tańca.", Quantity = 25, Author = "Justin Timberlake", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Attention", Description = "Chwytliwy hit Charlie'go Puth o relacjach i pragnieniu uwagi.", Quantity = 22, Author = "Charlie Puth", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Don't Let Me Down", Description = "Energetyczny utwór The Chainsmokers z Daya.", Quantity = 20, Author = "The Chainsmokers ft. Daya", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "I Like It", Description = "Radosny utwór Cardi B z Bad Bunny i J Balvin.", Quantity = 18, Author = "Cardi B ft. Bad Bunny & J Balvin", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Sicko Mode", Description = "Energetyczny utwór Travis Scott z dynamicznymi zmianami.", Quantity = 20, Author = "Travis Scott", MusicType = "Hip-Hop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "No Tears Left to Cry", Description = "Optymistyczny utwór Ariany Grande o powrocie do normalności.", Quantity = 25, Author = "Ariana Grande", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "God Is a Woman", Description = "Mocny utwór Ariany Grande o mocy i pewności siebie.", Quantity = 22, Author = "Ariana Grande", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Side to Side", Description = "Energetyczny utwór Ariany Grande z Nicki Minaj.", Quantity = 20, Author = "Ariana Grande ft. Nicki Minaj", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Starboy", Description = "Stylowy utwór The Weeknd o luksusach i sukcesie.", Quantity = 25, Author = "The Weeknd", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Heartless", Description = "Tajemniczy utwór The Weeknd o miłości i zdradzie.", Quantity = 22, Author = "The Weeknd", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Kiss Me More", Description = "Romantyczny hit Doja Cat i SZA.", Quantity = 20, Author = "Doja Cat ft. SZA", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Save Your Tears", Description = "Melancholijny utwór The Weeknd o stracie i żalu.", Quantity = 25, Author = "The Weeknd", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Need to Know", Description = "Energetyczny utwór Doja Cat o pragnieniu i przyciąganiu.", Quantity = 22, Author = "Doja Cat", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Happier Than Ever", Description = "Emocjonalny utwór Billie Eilish o refleksji i osobistym rozwoju.", Quantity = 22, Author = "Billie Eilish", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Bad Guy", Description = "Chwytliwy utwór Billie Eilish z nowoczesnym brzmieniem.", Quantity = 20, Author = "Billie Eilish", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Midnight City", Description = "Energiczny utwór M83 z syntezatorowym brzmieniem.", Quantity = 18, Author = "M83", MusicType = "Electronic", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Titanium", Description = "Potężny utwór David Guetta z Sia o sile i determinacji.", Quantity = 25, Author = "David Guetta ft. Sia", MusicType = "Electronic", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Wake Me Up", Description = "Hit Avicii z połączeniem folku i elektroniki.", Quantity = 22, Author = "Avicii", MusicType = "Electronic", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Strobe", Description = "Epicki utwór Deadmau5 z klimatycznym brzmieniem.", Quantity = 20, Author = "Deadmau5", MusicType = "Electronic", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Go!" , Description = "Dynamiczny utwór The Chemical Brothers z energetycznym beatem.", Quantity = 18, Author = "The Chemical Brothers", MusicType = "Electronic", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Toxic", Description = "Chwytliwy utwór Britney Spears z charakterystycznym beatem.", Quantity = 25, Author = "Britney Spears", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Gimme More", Description = "Energetyczny hit Britney Spears o pragnieniu więcej.", Quantity = 22, Author = "Britney Spears", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Single Ladies", Description = "Energetyczny utwór Beyoncé o niezależności.", Quantity = 20, Author = "Beyoncé", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Halo", Description = "Wzruszający utwór Beyoncé o miłości i duchowości.", Quantity = 18, Author = "Beyoncé", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Rolling in the Deep", Description = "Emocjonalny hit Adele o zdradzie i rozczarowaniu.", Quantity = 26, Author = "Adele", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Someone Like You", Description = "Wzruszający utwór Adele o stracie i pamięci.", Quantity = 22, Author = "Adele", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Chasing Pavements", Description = "Emocjonalny utwór Adele o poszukiwaniu sensu.", Quantity = 20, Author = "Adele", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Vogue", Description = "Ikoniczny utwór Madonny o modzie i wyrażaniu siebie.", Quantity = 25, Author = "Madonna", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Like a Prayer", Description = "Mocny utwór Madonny o duchowości i odkupieniu.", Quantity = 22, Author = "Madonna", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Express Yourself", Description = "Radosny utwór Madonny o wyrażaniu siebie.", Quantity = 20, Author = "Madonna", MusicType = "Pop", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Jailhouse Rock", Description = "Klasyczny utwór Elvisa Presleya o życiu w więzieniu.", Quantity = 18, Author = "Elvis Presley", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Hound Dog", Description = "Energetyczny hit Elvisa Presleya o złamanym sercu.", Quantity = 25, Author = "Elvis Presley", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Purple Haze", Description = "Ikoniczny utwór Jimi'ego Hendrixa z eksperymentalnym brzmieniem.", Quantity = 22, Author = "Jimi Hendrix", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Little Wing", Description = "Wzruszający utwór Jimi'ego Hendrixa o marzeniach i tęsknocie.", Quantity = 20, Author = "Jimi Hendrix", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "The Sound of Silence", Description = "Klasyczny utwór Simon & Garfunkel o ciszy i refleksji.", Quantity = 25, Author = "Simon & Garfunkel", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Bridge Over Troubled Water", Description = "Wzruszający utwór Simon & Garfunkel o wsparciu i nadziei.", Quantity = 22, Author = "Simon & Garfunkel", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Wish You Were Here", Description = "Emocjonalny utwór Pink Floyd o tęsknocie i stracie.", Quantity = 20, Author = "Pink Floyd", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Comfortably Numb", Description = "Klasyczny utwór Pink Floyd z głębokim brzmieniem.", Quantity = 18, Author = "Pink Floyd", MusicType = "Rock", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Smells Like Teen Spirit", Description = "Hymn grunge'u zespołu Nirvana.", Quantity = 18, Author = "Nirvana", MusicType = "Grunge", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Come As You Are", Description = "Ikoniczny utwór Nirvany o akceptacji i autentyczności.", Quantity = 20, Author = "Nirvana", MusicType = "Grunge", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Heart-Shaped Box", Description = "Mocny utwór Nirvany o miłości i izolacji.", Quantity = 22, Author = "Nirvana", MusicType = "Grunge", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Paranoid Android", Description = "Epicki utwór Radiohead o emocjach i technice.", Quantity = 25, Author = "Radiohead", MusicType = "Alternative", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Creep", Description = "Wzruszający utwór Radiohead o odczuwanym alienacji.", Quantity = 22, Author = "Radiohead", MusicType = "Alternative", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Knights of Cydonia", Description = "Energetyczny utwór Muse o fantastycznych motywach.", Quantity = 20, Author = "Muse", MusicType = "Alternative", ImagePath = "/images/music/default-image.jpg" },
                new Music() { Title = "Uprising", Description = "Mocny utwór Muse o walce i oporze.", Quantity = 18, Author = "Muse", MusicType = "Alternative", ImagePath = "/images/music/default-image.jpg" },
            };

            return musicList;
        }

        private IEnumerable<Film> GetFilms()
        {
            List<Film> filmList = new List<Film>()
            {
                new Film { Title = "Ona", Description = "Samotny pisarz nawiązuje nietypową relację z systemem operacyjnym, stworzonym, aby spełniać jego potrzeby.", Director = "Spike Jonze", FilmType = "Romans", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Światło księżyca", Description = "Młody Afroamerykanin zmaga się z tożsamością i seksualnością, przechodząc przez dzieciństwo, młodość i dorosłość.", Director = "Barry Jenkins", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Latarnia morska", Description = "Dwaj latarnicy próbują zachować zdrowie psychiczne na odległej, tajemniczej wyspie w Nowej Anglii.", Director = "Robert Eggers", FilmType = "Horror", ImagePath = "/images/films/default-image.jpg", Quantity = 5 },
                new Film { Title = "Zielona Mila", Description = "Strażnik więzienny odkrywa, że jeden z więźniów posiada nadprzyrodzone zdolności.", Director = "Frank Darabont", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Władca Pierścieni: Drużyna Pierścienia", Description = "Młody hobbit Frodo wyrusza na misję zniszczenia potężnego pierścienia.", Director = "Peter Jackson", FilmType = "Fantasy", ImagePath = "/images/films/default-image.jpg", Quantity = 12 },
                new Film { Title = "Leon zawodowiec", Description = "Zawodowy zabójca nawiązuje przyjaźń z młodą dziewczyną, której rodzina została zamordowana.", Director = "Luc Besson", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Ojciec chrzestny", Description = "Kronika życia potężnej mafijnej rodziny Corleone.", Director = "Francis Ford Coppola", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 15 },
                new Film { Title = "Skazani na Shawshank", Description = "Mężczyzna niesłusznie skazany na dożywocie nawiązuje więzi w więzieniu, planując ucieczkę.", Director = "Frank Darabont", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Incepcja", Description = "Zespół specjalistów wchodzi do snów, aby dokonać kradzieży tajemnic z podświadomości.", Director = "Christopher Nolan", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 12 },
                new Film { Title = "Interstellar", Description = "Grupa astronautów wyrusza na misję ratowania ludzkości, podróżując przez kosmiczne wymiary.", Director = "Christopher Nolan", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Matrix", Description = "Haker odkrywa, że rzeczywistość, w której żyje, to symulacja komputerowa stworzona przez maszyny.", Director = "Lana i Lilly Wachowski", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 11 },
                new Film { Title = "Gladiator", Description = "Rzymski generał staje się gladiatorem, aby zemścić się na cesarzu, który zdradził jego rodzinę.", Director = "Ridley Scott", FilmType = "Historyczny", ImagePath = "/images/films/default-image.jpg", Quantity = 14 },
                new Film { Title = "Lista Schindlera", Description = "Historia niemieckiego przedsiębiorcy, który ratował Żydów podczas Holokaustu.", Director = "Steven Spielberg", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Django", Description = "Wyzwolony niewolnik łączy siły z niemieckim łowcą nagród, aby uwolnić swoją żonę.", Director = "Quentin Tarantino", FilmType = "Western", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Pulp Fiction", Description = "Przeplatające się historie przestępców, boksera i pary złodziei w Los Angeles.", Director = "Quentin Tarantino", FilmType = "Kryminalny", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Piękny umysł", Description = "Geniusz matematyczny zmaga się ze schizofrenią, próbując jednocześnie prowadzić normalne życie.", Director = "Ron Howard", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Czarny łabędź", Description = "Balerina walczy z własnymi demonami, przygotowując się do roli w \"Jeziorze Łabędzim\".", Director = "Darren Aronofsky", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 5 },
                new Film { Title = "Grand Budapest Hotel", Description = "Przygody ekscentrycznego konsjerża hotelowego w fikcyjnym europejskim państwie.", Director = "Wes Anderson", FilmType = "Komedia", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Titanic", Description = "Romans Jacka i Rose na tle katastrofy słynnego statku Titanic.", Director = "James Cameron", FilmType = "Romans", ImagePath = "/images/films/default-image.jpg", Quantity = 12 },
                new Film { Title = "Gwiezdne wojny: Nowa nadzieja", Description = "Młody Luke Skywalker dołącza do walki z Imperium, aby ocalić galaktykę.", Director = "George Lucas", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 13 },
                new Film { Title = "Avatar", Description = "Były żołnierz trafia na obcą planetę, gdzie angażuje się w walkę o jej przyszłość.", Director = "James Cameron", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 14 },
                new Film { Title = "Mroczny Rycerz", Description = "Batman stawia czoła Jokerowi, który sieje chaos w Gotham City.", Director = "Christopher Nolan", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 15 },
                new Film { Title = "To nie jest kraj dla starych ludzi", Description = "Łowca nagród i morderca ścigają mężczyznę, który znalazł walizkę z pieniędzmi po nieudanej transakcji narkotykowej.", Director = "Joel i Ethan Coen", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Przełęcz ocalonych", Description = "Historia żołnierza, który odmówił noszenia broni, ale podczas II wojny światowej uratował wielu ludzi.", Director = "Mel Gibson", FilmType = "Wojenny", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Mad Max: Na drodze gniewu", Description = "W postapokaliptycznym świecie, Max łączy siły z kobietą, aby uciec przed tyranem.", Director = "George Miller", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Shrek", Description = "Ogr wyrusza na misję ratowania księżniczki, aby odzyskać swój bagienny dom.", Director = "Andrew Adamson, Vicky Jenson", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 12 },
                new Film { Title = "W głowie się nie mieści", Description = "Emocje młodej dziewczynki walczą o kontrolę nad jej zachowaniem po przeprowadzce do nowego miasta.", Director = "Pete Docter", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Pianista", Description = "Historia wybitnego pianisty, który przetrwał okupację warszawskiego getta podczas II wojny światowej.", Director = "Roman Polański", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "American Psycho", Description = "Młody, bogaty bankier prowadzi podwójne życie jako morderca i psychopata.", Director = "Mary Harron", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Herbata w Berlinie", Description = "Przypadkowe spotkanie w kawiarni w Berlinie prowadzi do nieoczekiwanej przyjaźni i odkryć.", Director = "Christian Petzold", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 5 },
                new Film { Title = "Wielki Gatsby", Description = "Opowieść o bogatym, tajemniczym mężczyźnie i jego obsesji na punkcie przeszłości.", Director = "Baz Luhrmann", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Jak zostać królem", Description = "Historia księcia, który zmaga się z jąkaniem i przygotowuje się do roli króla w obliczu II wojny światowej.", Director = "Tom Hooper", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Człowiek na krawędzi", Description = "Syndrom wyczerpania psychicznego prowadzi głównego bohatera do działania w niezwykle ryzykowny sposób.", Director = "Jaume Collet-Serra", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Zanim zasnę", Description = "Kobieta budzi się każdego dnia nie pamiętając, co się wydarzyło wczoraj, i odkrywa mroczne sekrety swojego życia.", Director = "Rowan Joffe", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 5 },
                new Film { Title = "Na skraju jutra", Description = "Żołnierz zostaje wciągnięty w pętlę czasową podczas walki z obcymi i musi odnaleźć sposób na przeżycie.", Director = "Doug Liman", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Goryl wśród ludzi", Description = "Goryl zamieszkujący zoo staje się celem kontrowersyjnego badania nad inteligencją zwierząt.", Director = "Peter Hedges", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Niepamięć", Description = "Po wojnie przyszłości człowiek odkrywa, że rzeczywistość, w której żyje, jest tylko iluzją.", Director = "Joseph Kosinski", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Miejsce pod słońcem", Description = "Przypadkowe spotkanie wśród dzikich roślin prowadzi do odkrycia osobistych i społecznych problemów bohatera.", Director = "Ben Stiller", FilmType = "Przygodowy", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Głosy", Description = "Mężczyzna w psychiatrycznym szpitalu odkrywa, że jego życie jest sterowane przez głosy w jego głowie.", Director = "Marjane Satrapi", FilmType = "Komedia", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Królowie nocy", Description = "Bohaterowie nocnego życia metropolii zmierzają do przetrwania w okrutnym świecie przestępczym.", Director = "Nicolas Winding Refn", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Pakt z diabłem", Description = "Wykładowca akademicki zostaje wciągnięty w mroczny układ z demoniczną siłą.", Director = "Scott Derrickson", FilmType = "Horror", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Dzień, w którym zatrzymała się Ziemia", Description = "Obcy przybywa na Ziemię z ostrzeżeniem dla ludzkości i odkrywa ludzkie tragedie oraz nadzieje.", Director = "Robert Wise", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 5 },
                new Film { Title = "Zazdrość", Description = "Skryta zazdrość wobec partnerki prowadzi do nieoczekiwanych dramatycznych wydarzeń.", Director = "Philippe Garrel", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Joker", Description = "Pojmanie i przemiana człowieka w ikonicznego złoczyńcę Gotham City.", Director = "Todd Phillips", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Kapitan Marvel", Description = "Była żołnierz odkrywa swoje prawdziwe pochodzenie jako superbohaterka w konflikcie między dwoma obcymi rasami.", Director = "Anna Boden, Ryan Fleck", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Sokół z masy", Description = "Zawodowy zabójca na tropie jednego z największych zleceniodawców przestępczych świata.", Director = "J.C. Chandor", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Ona była jedyną", Description = "Miłość i zdrada przeplatają się w życiu głównego bohatera, gdy zaczyna odkrywać mroczne sekrety swojego otoczenia.", Director = "David Fincher", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Noc w muzeum", Description = "Noce w muzeum zmieniają się w niezwykłą przygodę, gdy eksponaty zaczynają ożywać.", Director = "Shawn Levy", FilmType = "Familijny", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Królestwo zwierząt", Description = "Przemoc i zdrada w rodzinie przestępczej prowadzą do tragicznych konsekwencji w społeczeństwie.", Director = "David Michôd", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Psychoza", Description = "Kobieta na ucieczce przed prześladowcą trafia do tajemniczego motelu, gdzie odkrywa mroczne tajemnice.", Director = "Alfred Hitchcock", FilmType = "Horror", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Spotlight", Description = "Dziennikarze z Boston Globe odkrywają skandal dotyczący nadużyć seksualnych w Kościele katolickim.", Director = "Tom McCarthy", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Jumanji: Przygoda w dżungli", Description = "Grupa przyjaciół zostaje wciągnięta do gry planszowej, gdzie muszą stawić czoła niebezpieczeństwom dżungli.", Director = "Jake Kasdan", FilmType = "Przygodowy", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Szybcy i wściekli", Description = "Kierowcy wyścigowi i przestępcy łączą siły w akcji i wyścigach pełnych adrenaliny.", Director = "Rob Cohen", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 12 },
                new Film { Title = "Człowiek-ryba", Description = "Młody mężczyzna odkrywa swoje niezwykłe umiejętności w wodzie, które prowadzą go do odkrycia tajemnic jego przeszłości.", Director = "Guillermo del Toro", FilmType = "Fantasy", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Zimowa opowieść", Description = "Historia miłości i magii w Nowym Jorku, rozgrywająca się w dwóch równoległych rzeczywistościach.", Director = "Akiva Goldsman", FilmType = "Fantasy", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Ostatni samuraj", Description = "Amerykański wojskowy zostaje wciągnięty w konflikt z samurajami w Japonii, ucząc się o ich kulturze i honorze.", Director = "Edward Zwick", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Jak wytresować smoka", Description = "Młody wiking zaprzyjaźnia się z drakonem, co zmienia jego postrzeganie świata i relacje z własnym ludem.", Director = "Dean DeBlois, Chris Sanders", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "W pogoni za szczęściem", Description = "Mężczyzna walczy z przeciwnościami losu, aby zapewnić lepsze życie dla siebie i swojego syna.", Director = "Gabriele Muccino", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Niebezpieczna metoda", Description = "Historia początków psychoanalizy i konfliktu między Sigmundem Freudem a Carlosem Jungiem.", Director = "David Cronenberg", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Hobbit: Niezwykła podróż", Description = "Bilbo Baggins wyrusza na niebezpieczną wyprawę, aby pomóc grupie krasnoludów odzyskać ich królestwo.", Director = "Peter Jackson", FilmType = "Fantasy", ImagePath = "/images/films/default-image.jpg", Quantity = 10 },
                new Film { Title = "Kapitan Phillips", Description = "Historia prawdziwych wydarzeń dotyczących porwania amerykańskiego statku przez somalijskich piratów.", Director = "Paul Greengrass", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Krew na piasku", Description = "Podczas brutalnej wojny, żołnierz odkrywa mroczne tajemnice wojenne, które zmieniają jego życie.", Director = "David Ayer", FilmType = "Wojenny", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Żona podróżnika w czasie", Description = "Miłość między kobietą a mężczyzną, który ma zdolność podróżowania w czasie, prowadzi do wielu wzruszających chwil.", Director = "Robert Schwentke", FilmType = "Romans", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Koralina i tajemnicze drzwi", Description = "Dziewczynka odkrywa równoległy świat, który na początku wydaje się idealny, ale skrywa mroczne tajemnice.", Director = "Henry Selick", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Dziecko Rosemary", Description = "Kobieta w ciąży odkrywa, że jej mąż i sąsiedzi mają mroczne plany dotyczące jej dziecka.", Director = "Roman Polański", FilmType = "Horror", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Moje życie z Marilyn", Description = "Opowieść o młodym asystencie, który spędza czas z ikoną Hollywood, Marilyn Monroe, odkrywając jej osobiste zmagania.", Director = "Simon Curtis", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 5 },
                new Film { Title = "Borat", Description = "Fikcyjny dziennikarz z Kazachstanu podróżuje po USA, dokumentując absurdalne i komiczne sytuacje.", Director = "Larry Charles", FilmType = "Komedia", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Smerfy", Description = "Smerfy muszą wrócić do swojego świata po tym, jak zostają przeniesione do współczesnego Nowego Jorku.", Director = "Raja Gosnell", FilmType = "Familijny", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Gra o tron: Gra o tron", Description = "Różne rody walczą o kontrolę nad Westeros, odkrywając mroczne sekrety i niebezpieczeństwa.", Director = "David Benioff, D.B. Weiss", FilmType = "Fantasy", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Hotel Transylwania", Description = "Hotel dla potworów prowadzony przez Drakulę staje się miejscem, gdzie potwory mogą odpocząć przed ludzkim światem.", Director = "Genndy Tartakovsky", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Wielki błękit", Description = "Konkurs pływacki między dwoma zawodnikami, który prowadzi do głębszej rywalizacji i osobistych odkryć.", Director = "Luc Besson", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Skała", Description = "Były agent FBI i skazaniec łączą siły, aby powstrzymać terrorystów planujących zamach na San Francisco.", Director = "Michael Bay", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Człowiek z Wysokiego Zamku", Description = "Alternatywna rzeczywistość, w której Państwa Osi wygrały II wojnę światową i podzieliły Stany Zjednoczone.", Director = "Frank Spotnitz", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "RoboCop", Description = "RoboCop, cyborg policjant, walczy z przestępczością w dystopijnym Detroit, odkrywając tajemnice swojego ludzkiego pochodzenia.", Director = "Paul Verhoeven", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Twój znak", Description = "Młoda kobieta odkrywa, że jej przyszłość jest związana z tajemniczymi wydarzeniami w jej małym miasteczku.", Director = "Rian Johnson", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Hercules", Description = "Mitologiczny bohater, Hercules, musi stawić czoła swoim demonom i udowodnić swoją wartość.", Director = "Brett Ratner", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Kung Fu Panda", Description = "Niezwykły panda marzy o zostaniu mistrzem kung-fu i musi stawić czoła złowrogim wrogom.", Director = "Mark Osborne, John Stevenson", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Służące", Description = "Historia czarnoskórych służących, które opowiadają o swoich trudnych doświadczeniach w latach 60. w USA.", Director = "Tate Taylor", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Wszystko za życie", Description = "Młody mężczyzna porzuca swoje wygodne życie, aby wyruszyć w podróż po USA, odkrywając siebie i życie w drodze.", Director = "Sean Penn", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Mad Max: Na drodze gniewu", Description = "Postapokaliptyczna wizja świata, w której Max i Furiosa walczą o przetrwanie i wolność przeciwko despockim władcom.", Director = "George Miller", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Powrót do przyszłości", Description = "Młody nastolatek zostaje przypadkowo przeniesiony w przeszłość i musi upewnić się, że jego rodzice się spotkają, aby uratować swoje własne istnienie.", Director = "Robert Zemeckis", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Sekretne życie zwierzaków domowych", Description = "Opowieść o tym, co zwierzęta robią, gdy ich właściciele są poza domem.", Director = "Chris Renaud, Yarrow Cheney", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Jumanji: Następny poziom", Description = "Grupa przyjaciół wraca do gry Jumanji, aby uratować jednego z nich, stawiając czoła jeszcze większym wyzwaniom.", Director = "Jake Kasdan", FilmType = "Przygodowy", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Na zawsze", Description = "Opowieść o miłości i wyborach, które mogą odmienić życie dwojga ludzi na zawsze.", Director = "Michael Sucsy", FilmType = "Romans", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Krucjata Bourne’a", Description = "Jason Bourne odkrywa więcej tajemnic swojej przeszłości, gdy jest ścigany przez różne agencje rządowe.", Director = "Paul Greengrass", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Prawdziwe męstwo", Description = "Młoda dziewczyna zatrudnia twardego szeryfa, aby pomścił śmierć jej ojca, podróżując przez dziki Zachód.", Director = "Joel Coen, Ethan Coen", FilmType = "Western", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Sully", Description = "Historia pilota, który lądował awaryjnie na rzece Hudson, ratując pasażerów i stając w obliczu śledztwa.", Director = "Clint Eastwood", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Głowa do wycierania", Description = "Mężczyzna odkrywa, że jego życie jest pod ciągłym nadzorem, gdy zmienia się w groteskowy bohater sztuk teatralnych.", Director = "Lars von Trier", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 5 },
                new Film { Title = "Gnijąca panna młoda", Description = "Opowieść o mężczyźnie, który przypadkowo oświadcza się martwej dziewczynie w trakcie złożonego ślubu.", Director = "Tim Burton", FilmType = "Animacja", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Gran Torino", Description = "Starszy weteran wojenny próbuje nawiązać więź z sąsiadami, a jego życie zmienia się po konflikcie z lokalnymi gangami.", Director = "Clint Eastwood", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Porywacze ciał", Description = "Grupa ludzi walczy o przetrwanie, gdy zostają wciągnięci w inwazję obcych, którzy zamieniają ludzi w bezwolne marionetki.", Director = "Don Siegel", FilmType = "Horror", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Pakt z diabłem", Description = "Prawnik zawiera mroczny układ z diabłem, aby uratować swoją rodzinę, ale konsekwencje są druzgocące.", Director = "Scott Derrickson", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Morderstwo w Orient Expressie", Description = "Detektyw Hercule Poirot prowadzi śledztwo w sprawie morderstwa na luksusowym pociągu, odkrywając skomplikowaną sieć kłamstw.", Director = "Kenneth Branagh", FilmType = "Kryminał", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Nocny recepcjonista", Description = "Recepcjonista hotelowy zostaje wciągnięty w świat przestępczy, gdy odkrywa mroczne tajemnice swojego klienta.", Director = "Stephen Hopkins", FilmType = "Thriller", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Ostatni rycerz", Description = "W średniowiecznym królestwie, grupa rycerzy staje do walki przeciwko złemu władcy, aby ocalić swoje królestwo.", Director = "Kazuaki Kiriya", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Dzień niepodległości", Description = "Ludzkość jednoczy się w walce z obcymi najeźdźcami, którzy planują zniszczyć Ziemię.", Director = "Roland Emmerich", FilmType = "Sci-Fi", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Za każdym razem", Description = "Opowieść o uczuciach i relacjach, które rozwijają się i zmieniają przez lata, w miarę jak bohaterowie dorastają.", Director = "Richard Linklater", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Wielki Gatsby", Description = "Ekranizacja klasycznej powieści o tajemniczym bogaczu i jego obsesji na punkcie dawnej miłości.", Director = "Baz Luhrmann", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 8 },
                new Film { Title = "Podziemny krąg", Description = "Mężczyzna zakłada tajne stowarzyszenie, które szybko przekształca się w anarchistyczny ruch destrukcyjny.", Director = "David Fincher", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 9 },
                new Film { Title = "Wieczór panieński", Description = "Grupa przyjaciół wyjeżdża na weekendowy wypad, który szybko wymyka się spod kontroli, prowadząc do chaotycznych wydarzeń.", Director = "Leslye Headland", FilmType = "Komedia", ImagePath = "/images/films/default-image.jpg", Quantity = 6 },
                new Film { Title = "Sucker Punch", Description = "Młoda kobieta zostaje uwięziona w szpitalu psychiatrycznym i wkrótce ucieka do świata wyobraźni, aby uciec od rzeczywistości.", Director = "Zack Snyder", FilmType = "Akcja", ImagePath = "/images/films/default-image.jpg", Quantity = 7 },
                new Film { Title = "Ziemia obiecana", Description = "Opowieść o walce o kontrolę nad ziemią w XIX-wiecznej Polsce, pełna intryg i osobistych zmagań.", Director = "Andrzej Wajda", FilmType = "Dramat", ImagePath = "/images/films/default-image.jpg", Quantity = 5 }
            };

            return filmList;
        }
    }
}
