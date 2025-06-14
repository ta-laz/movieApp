using System.Runtime.CompilerServices;


// The models generally represent the data that the app uses
// In other words this is the data model we're gonna be using to describe a movie object with the given properties 
// namespace specifically is used to organise code, so this here tells us the class we are defining lives inside Models in the
// movieApp project. And this will be what we use to call the model later in other files 

// the get; set; thing is how C# allows the reading (get) and writing (set) of elements
//the long form of get; set; is:

// private string _title;           this is where the actual data is held 
// public string Title              this controls how the outside world can access that data 
// {
//     get { return _title; }       if you did movie.Title then it'd run "get" and return _title 
//     set { _title = value; }      if you did movie.Title = "Barbie", it'd run set and store a new value in _title
// }


namespace movieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public string? Synopsis { get; set; }
    }
}