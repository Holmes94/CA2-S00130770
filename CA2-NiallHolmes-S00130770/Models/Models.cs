using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2_NiallHolmes_S00130770.Models
{
    public class MovieDBInitializer : DropCreateDatabaseAlways<MovieDB>
    {
        protected override void Seed(MovieDB context)
        {
            context.Movies.Add(new Movie()
            {
                MovieName = "Bruce Almighty",
                Genre = Models.Genre.Comedy,
                Actors = new List<Actor> 
                {
                    new Actor(){ActorName="Jim Carrey", ActorScreenName = "Bruce Almighty"},
                    new Actor(){ActorName="Morgan Freeman", ActorScreenName = "God"}
                }
            });

            context.Movies.Add(new Movie()
            {
                MovieName = "Dumb and Dumber",
                Genre = Models.Genre.Comedy,
                Actors = new List<Actor> 
                {
                    new Actor(){ActorName="Jim Carrey", ActorScreenName = " Lloyd Christmas"},
                    new Actor(){ActorName="Jeff Daniels", ActorScreenName = "Harry Dunne" }
                }
            });

            context.Movies.Add(new Movie()
            {
                MovieName = "Bourne Identity",
                Genre = Models.Genre.Action,
                Actors = new List<Actor> 
                {
                    new Actor(){ActorName="Matt Damon", ActorScreenName = "Jason Bourne"},
                    new Actor(){ActorName="Franka Potente ", ActorScreenName = "Marie Helena Kreutz" }
                }
            });

            context.Movies.Add(new Movie()
            {
                MovieName = "8 Mile",
                Genre = Models.Genre.Drama,
                Actors = new List<Actor> 
                {
                    new Actor(){ActorName="Eminem", ActorScreenName = "B-Rabbit"},
                    new Actor(){ActorName="Mekhi Phifer", ActorScreenName = "David Porter" }
                }
            });

            context.Movies.Add(new Movie()
            {
                MovieName = "Invictus",
                Genre = Models.Genre.Drama,
                Actors = new List<Actor> 
                {
                    new Actor(){ActorName="Morgan Freeman", ActorScreenName = "Nelson Mandela"},
                    new Actor(){ActorName="Matt Damon", ActorScreenName = "François Pienaar" }
                }
            });
            context.SaveChanges();
            base.Seed(context);
            
        }
    }//end

    public enum Genre { Comedy, Horror, Action, Crime, Drama, Romance, Animation};

    public class Movie
    {
        public int MovieID { get; set; }
        [DisplayName("Movie Name"), Required]
        public string MovieName { get; set; }
        [DisplayName("Movie Genre"), Required]
        public Genre Genre { get; set; }
        public virtual List<Actor> Actors { get; set; }
       
    }//end movie

    public class Actor
    {
        public int ActorID { get; set; }
        [DisplayName("Actor Name"), Required]
        public string ActorName { get; set; }
        [DisplayName("Character Name"), Required]
        public string ActorScreenName { get; set; }
        public int MovieID { get; set; }
        public virtual List<Movie> Movie { get; set; }

    }//end actor

    public class MovieDB : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public MovieDB():base("MovieDB")
        {

        }
    }// end dbcontext

    //public class MovieActor
    //{
    //   // [Key, Column(Order = 0)]    
    //    public int MovieID { get; set; }
    //    //[Key, Column(Order = 1)]      
    //    public int ActorID { get; set; }
    //    // Nav Properties
    //    public virtual Movie Movie { get; set; }
    //    public virtual Actor Actor { get; set; }
    //}

}//end model