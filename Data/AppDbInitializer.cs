using eCommerceTest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceTest.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Description = "This is the description for cinema 1",
                            Logo = "https://thumbs.dreamstime.com/z/cine-creativo-logo-vector-art-110521002.jpg"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Description = "This is the description for cinema 2",
                            Logo = "https://i.pinimg.com/600x315/87/f5/91/87f591e724f9902e6b33cc8cbdd05115.jpg"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Description = "This is the description for cinema 3",
                            Logo = "http://assets.stickpng.com/thumbs/5ef1c4c51cfbc200047e742d.png"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Description = "This is the description for cinema 4",
                            Logo = "https://upload.wikimedia.org/wikipedia/commons/8/8d/CineColombia.png"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Description = "This is the description for cinema 5",
                            Logo = "https://play-lh.googleusercontent.com/N4NgtRDzsHSceUAmEPShNnOc23zG_kvqE_4BPDvHpNWWBnQR6-W8SDg150-Kc_chq24"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the bio for actor 1",
                            ProfilePictureURL = "https://aws.revistavanityfair.es/prod/designs/v1/assets/785x589/40611.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the bio for actor 2",
                            ProfilePictureURL = "https://resizer.glanacion.com/resizer/B7otP7-ogJBRocEey3v8NIwimgI=/768x0/filters:quality(80)/cloudfront-us-east-1.images.arcpublishing.com/lanacionar/GRAELYHQLVD7TKISVLPUGXIBJU.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the bio for actor 3",
                            ProfilePictureURL = "https://static.wikia.nocookie.net/riverdale/images/5/5a/Lucy_Hale.png/revision/latest?cb=20191006152417&path-prefix=es"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the bio for actor 4",
                            ProfilePictureURL = "https://static.wikia.nocookie.net/sex-education-netflix/images/4/43/Otis_Milburn_Season_1_Portrait.jpg/revision/latest?cb=20190902201801"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the bio for actor 5",
                            ProfilePictureURL = "https://static.wikia.nocookie.net/sex-education-netflix/images/a/a8/Maeve_Wiley_Season_1_Portrait.jpg/revision/latest?cb=20190902212135"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/7/7c/Eugenio_Derbez.png",
                            FullName = "Producer 1",
                            Bio = "This is the bio for producer 1"
                        },
                        new Producer()
                        {
                            ProfilePictureURL = "https://tentulogo.com/wp-content/uploads/cabecera-post-steven-Spielberg-cover.jpg",
                            FullName = "Producer 2",
                            Bio = "This is the bio for producer 2"
                        },
                        new Producer()
                        {
                            ProfilePictureURL = "https://cinemavenue.files.wordpress.com/2016/04/stanley-kucrick.jpg?w=820",
                            FullName = "Producer 3",
                            Bio = "This is the bio for producer 3"
                        },
                        new Producer()
                        {
                            ProfilePictureURL = "https://cines.com/files/2020/06/winkler-productores-cine.jpg",
                            FullName = "Producer 4",
                            Bio = "This is the bio for producer 4"
                        },
                        new Producer()
                        {
                            ProfilePictureURL = "https://as.com/ocio/imagenes/2015/02/23/cine/1424681286_185328_1424681743_noticia_grande.jpg",
                            FullName = "Producer 5",
                            Bio = "This is the bio for producer 5"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Movie 1",
                            Description = "This is the description for movie 1",
                            Price = 35.00,
                            Image = "https://image.api.playstation.com/vulcan/img/rnd/202011/0714/vuF88yWPSnDfmFJVTyNJpVwW.png",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Movie 2",
                            Description = "This is the description for movie 2",
                            Price = 55.00,
                            Image = "https://static.wikia.nocookie.net/doblaje/images/f/f9/TheHangover.jpg/revision/latest?cb=20101205171543&path-prefix=es",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "Movie 3",
                            Description = "This is the description for movie 3",
                            Price = 45.00,
                            Image = "https://pics.filmaffinity.com/que_culpa_tiene_el_nino-277653758-large.jpg",
                            StartDate = DateTime.Now.AddDays(2),
                            EndDate = DateTime.Now.AddDays(14),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Movie 4",
                            Description = "This is the description for movie 4",
                            Price = 30.00,
                            Image = "https://image.api.playstation.com/vulcan/img/rnd/202010/2716/8pc2fi23ksuIvi0gEHO5EqV2.png",
                            StartDate = DateTime.Now.AddDays(2),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name = "Movie 5",
                            Description = "This is the description for movie 5",
                            Price = 85.00,
                            Image = "https://kbimages1-a.akamaihd.net/7f109f0d-382c-47ea-ad96-b7c63f62a78c/1200/1200/False/cars-3-spanish-edition.jpg",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(5),
                            CinemaId = 4,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Horror
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
