using LibraryInfrastructure.Context;
using LibraryInfrastructure.Data;
using System.Collections.Generic;
using System.Linq;

public static class DataSeeder
{
    public static void SeedData(LibraryContext context)
    {
        if (context.Books.Any())
        {
            return;
        }

        var books = new List<Book>
            {
                new Book
                {
                    Title = "Myna Mazailo",
                    Cover = "https://images.gr-assets.com/books/1396505876l/27363624.jpg",
                    Content = "The novel tells the story of Myna, a young woman living in a Ukrainian village who falls in love with a man from a wealthy family. Despite the opposition of her family and community, Myna follows her heart and marries the man she loves. However, their happiness is short-lived, as the man's family begins to interfere in their relationship and Myna finds herself torn between her love for her husband and her loyalty to her own people.",
                    Genre = "Novel",
                    Author = "Mykola Kulish",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Message = "An excellent novel that captures the struggles of rural life in Ukraine.",
                            Reviewer = "Oksana Petrova"
                        },
                        new Review
                        {
                            Message = "Kulish is a true master of storytelling.",
                            Reviewer = "Ihor Kovalenko"
                        }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Score = 5
                        },
                        new Rating
                        {
                            Score = 4
                        }
                    }
                },
                new Book
                {
                    Title = "The Roads",
                    Cover = "https://images.gr-assets.com/books/1447256127l/1637176.jpg",
                    Content = "The Roads is a collection of short stories by Vasyl Stefanyk, one of the most important Ukrainian writers of the 19th century. The stories explore themes such as poverty, social injustice, and the struggle for human dignity.",
                    Genre = "Short stories",
                    Author = "Vasyl Stefanyk",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Message = "A great collection of stories that are still relevant today.",
                            Reviewer = "Ivan Hryhorchuk"
                        },
                        new Review
                        {
                            Message = "Stefanyk was a true champion of the Ukrainian people.",
                            Reviewer = "Kateryna Dubovych"
                        }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Score = 5
                        },
                        new Rating
                        {
                            Score = 4
                        }
                    }
                },
                new Book
                {
                    Title = "Moses",
                    Cover = "https://images.gr-assets.com/books/1330143362l/13494621.jpg",
                    Content = "Moses is a play by the Ukrainian writer Ivan Franko. It is a retelling of the biblical story of Moses, and is a powerful exploration of themes such as leadership, faith, and justice.",
                    Genre = "Drama",
                    Author = "Ivan Franko",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Message = "Franko's interpretation of Moses is brilliant.",
                            Reviewer = "Oksana Kovalenko"
                        },
                        new Review
                        {
                            Message = "A must-read for anyone interested in Ukrainian drama.",
                            Reviewer = "Andriy Mykhailenko"
                        }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Score = 5
                        },
                        new Rating
                        {
                            Score = 4
                        }
                    }
                },
                new Book
                {
                    Title = "The City",
                    Cover = "https://images.gr-assets.com/books/1486256829l/34211899.jpg",
                    Content = "The City is a novel by the Ukrainian writer Valerian Pidmohylny. It tells the story of a young man who moves to the city to seek his fortune, but finds himself caught up in a world of corruption, crime, and political turmoil.",
                    Genre = "Novel",
                    Author = "Valerian Pidmohylny",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Message = "Pidmohylny captures the spirit of the city perfectly.",
                            Reviewer = "Oksana Ivanenko"
                        },
                        new Review
                        {
                            Message = "A great read for anyone interested in Ukrainian literature.",
                            Reviewer = "Andriy Koval"
                        }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Score = 5
                        },
                        new Rating
                        {
                            Score = 4
                        }
                    }
                },
                new Book
                {
                    Title = "The Kobzar",
                    Cover = "https://images.gr-assets.com/books/1447263612l/26147831.jpg",
                    Content = "The Kobzar is a collection of epic poems and songs written by the Ukrainian poet Taras Shevchenko. It is considered one of the most important works in Ukrainian literature, and is an important part of Ukrainian culture.",
                    Genre = "Epic poetry",
                    Author = "Taras Shevchenko",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Message = "A must-read for anyone interested in Ukrainian culture.",
                            Reviewer = "Olena Petrenko"
                        },
                        new Review
                        {
                            Message = "Shevchenko is a true genius.",
                            Reviewer = "Ivan Kovalev"
                        }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Score = 5
                        },
                        new Rating
                        {
                            Score = 4
                        }
                    }
                },
                new Book
                {
                    Title = "The Forest Song",
                    Cover = "https://images.gr-assets.com/books/1537843097l/419639.jpg",
                    Content = "The Forest Song is a play by the Ukrainian writer Lesia Ukrainka. It is considered one of the most important works in Ukrainian drama, and is a powerful exploration of themes such as love, freedom, and the struggle for national identity.",
                    Genre = "Drama",
                    Author = "Lesia Ukrainka",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Message = "A brilliant play that still resonates today.",
                            Reviewer = "Kateryna Ivanenko"
                        },
                        new Review
                        {
                            Message = "Ukrainka is a master of the craft.",
                            Reviewer = "Petro Koval"
                        }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Score = 5
                        },
                        new Rating
                        {
                            Score = 4
                        }
                    }
                },
                new Book
                {
                    Title = "Shadows of Forgotten Ancestors",
                    Cover = "https://images.gr-assets.com/books/1389479838l/19322184.jpg",
                    Content = "Shadows of Forgotten Ancestors is a novel by the Ukrainian writer Mykhailo Kotsiubynsky. It tells the story of a young Hutsul who falls in love with a girl from a rival tribe, and is a powerful exploration of love, identity, and cultural conflict.",
                    Genre = "Novel",
                    Author = "Mykhailo Kotsiubynsky",
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Message = "Kotsiubynsky is a master storyteller.",
                            Reviewer = "Vasyl Ivanov"
                        },
                        new Review
                        {
                            Message = "A classic of Ukrainian literature.",
                            Reviewer = "Olena Kravchuk"
                        }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            Score = 4
                        },
                        new Rating
                        {
                            Score = 5
                        }
                    }
                },
                new Book                   
                {
                        Title = "The Stone Cross",
                        Cover = "https://images.gr-assets.com/books/1340008034l/6473722.jpg",
                        Content = "The Stone Cross is a novel by the Ukrainian writer Vasyl Stefanyk. It is a classic of Ukrainian literature, and tells the story of a young man who must choose between his love for a woman and his loyalty to his people.",
                        Genre = "Novel",
                        Author = "Vasyl Stefanyk",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Message = "A classic of Ukrainian literature.",
                                Reviewer = "Natalia Petrenko"
                            },
                            new Review
                            {
                                Message = "Stefanyk is a master storyteller.",
                                Reviewer = "Ivan Kovalenko"
                            }
                        },
                        Ratings = new List<Rating>
                        {
                            new Rating
                            {
                                Score = 4
                            },
                            new Rating
                            {
                                Score = 5
                            }
                        }
                },
                new Book
                    {
                     Title = "Tiger Hunters",
                     Cover = "https://images.gr-assets.com/books/1476893855l/32338497.jpg",
                     Content = "Tiger Hunters is a novel by the Ukrainian writer Ivan Bahrianyi. It is a classic of Ukrainian literature, and tells the story of a group of men who must face the dangers of the forest in order to catch a man-eating tiger.",
                     Genre = "Novel",
                     Author = "Ivan Bahrianyi",
                     Reviews = new List<Review>
                     {
                            new Review
                            {
                                Message = "A thrilling adventure story.",
                                Reviewer = "Oksana Kovalenko"
                            },
                            new Review
                            {
                                Message = "Bahrianyi is a master of suspense.",
                                Reviewer = "Petro Ivanenko"
                            }
                     },
                     Ratings = new List<Rating>
                     {
                            new Rating
                            {
                                Score = 5
                            },
                            new Rating
                            {
                                Score = 4
                            }
                        }
                    },
                new Book
                {
                        Title = "The Shipbuilder",
                        Cover = "https://images.gr-assets.com/books/1517127863l/38078417.jpg",
                        Content = "The Shipbuilder is a novel by the Ukrainian writer Yuriy Yanovsky. It tells the story of a man who must overcome great obstacles in order to build a ship that will carry him and his family to a new life.",
                        Genre = "Novel",
                        Author = "Yuriy Yanovsky",
                        Reviews = new List<Review>
                        {
                            new Review
                            {
                                Message = "A powerful story of determination and courage.",
                                Reviewer = "Olga Petrova"
                            },
                            new Review
                            {
                                Message = "Yanovsky is a master of character development.",
                                Reviewer = "Ihor Kovalenko"
                            }
                        },
                        Ratings = new List<Rating>
                        {
                            new Rating
                            {
                                Score = 4
                            },
                            new Rating
                            {
                                Score = 4
                            }
                        }
                }
            };

        context.Books.AddRange(books);
        context.SaveChanges();
    }
}

