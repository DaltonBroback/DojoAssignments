using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            
            var fromVernon = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Artists from Mount Vernon");
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Real Name: "+fromVernon.RealName);
            System.Console.WriteLine("Artist Name: "+fromVernon.ArtistName);
            System.Console.WriteLine("Age: "+fromVernon.Age);
            System.Console.WriteLine();

            //Who is the youngest artist in our collection of artists?

            var youngestArtist = Artists.OrderBy(artist => artist.Age).First();
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Youngest Artist");
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Real Name: "+youngestArtist.RealName);
            System.Console.WriteLine("Artist Name: "+youngestArtist.ArtistName);
            System.Console.WriteLine("Age: "+youngestArtist.Age);
            System.Console.WriteLine();

            //Display all artists with 'William' somewhere in their real name

            List<Artist> namedWilliam = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Artists Named William");
            System.Console.WriteLine("*************************");
            foreach(var artist in namedWilliam){
                System.Console.WriteLine("Real Name: "+artist.RealName);
                System.Console.WriteLine("Artist Name: "+artist.ArtistName);
                System.Console.WriteLine("Age: "+artist.Age);
                System.Console.WriteLine();
            }

            //Display all groups with names less than 8 characters in length.

            List<Group> lessThanEight = Groups.Where(group => group.GroupName.Length < 8).ToList();
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Groups Less Than 8 Characters in Title Length");
            System.Console.WriteLine("*************************");
            foreach(var group in lessThanEight){
                System.Console.WriteLine(group.GroupName);
                System.Console.WriteLine();
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> fromAtlanta = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).ToList().GetRange(1,3);
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("3 Oldest Artists from Atlanta");
            System.Console.WriteLine("*************************");
            foreach(var artist in fromAtlanta){
                System.Console.WriteLine("Real Name: "+artist.RealName);
                System.Console.WriteLine("Artist Name: "+artist.ArtistName);
                System.Console.WriteLine("Age: "+artist.Age);
                System.Console.WriteLine();
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            // List<Artist> notFromNY = Artists.Where(artist => artist.Hometown != "New York").ToList();
            // System.Console.WriteLine("Groups with at least 1 member not from NYC");
            // foreach(var artist in notFromNY){
            //     System.Console.WriteLine(artist.GroupId);
            //     System.Console.WriteLine();
            // }
            List<string> NonNewYorkGroups = Artists
                                            .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist;})
                                            .Where(artist => (artist.Hometown != "New York City" && artist.Group !=null))
                                            .Select(artist => artist.Group.GroupName)
                                            .Distinct()
                                            .ToList();
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Groups with at least 1 member not from NYC");
            System.Console.WriteLine("*************************");
            foreach(var group in NonNewYorkGroups){
                System.Console.WriteLine(group);
                System.Console.WriteLine();
            }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var WuTang = Groups.Where(group => group.GroupName == "Wu-Tang Clan").Single();
            List<Artist> inWuTang = Artists.Where(artist => artist.GroupId == WuTang.Id).ToList();
            System.Console.WriteLine("*************************");
            System.Console.WriteLine("Artists in the Wu-Tang Clan");
            System.Console.WriteLine("*************************");
            foreach(var artist in inWuTang){
                System.Console.WriteLine("Real Name: "+artist.RealName);
                System.Console.WriteLine("Artist Name: "+artist.ArtistName);
                System.Console.WriteLine("Age: "+artist.Age);
                System.Console.WriteLine();
            }
        }
    }
}
