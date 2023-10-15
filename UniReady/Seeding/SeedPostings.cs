using UniReady.DAL;
using UniReady.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace UniReady.Seeding
{
	public static class SeedPostings
	{
        public static void SeedAllPostings(AppDbContext db)
        {
            List<Posting> AllPostings = new List<Posting>();
            AllPostings.Add(new Posting
            {
                UniqueIdentifier = "718d888a9f382228a95c2",
                Title = "Financial Aid",
                Author = "Asilbek",
                Views = 0,
                PostedDate = new DateTime(2023,10,15),
                Summary = "UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.",
                Article = "UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.",
                MinimumSalary = 222m
            });
            AllPostings.Add(new Posting
            {
                UniqueIdentifier = "93812u9381knamsdasdkja23",
                Title = "Class Registration",
                Author = "Asilbek",
                Views = 5,
                PostedDate = new DateTime(2023, 10, 18),
                Summary = "CLASS Registration, talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.",
                Article = "UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.UT Austin is committed to enrolling and graduating the most talented Texas students by offering competitive recruitment and scholarship packages that make the university an option for high-potential students, regardless of income. Our commitment to affordability means making it possible for students to take full advantage of all that the university has to offer, in four-years, to reduce student costs and debt.",
                MinimumSalary = 22322m
            });

            //create some counters to help debug problems
            Int32 intPostingID = 0;
            String strPostingTitle = "Start";

            //loop through the list to add or update the job posting
            try
            {
                foreach (Posting seedPosting in AllPostings)
                {
                    //update the counters
                    intPostingID = seedPosting.PostingID;
                    strPostingTitle = seedPosting.Title;
                    //see if the job posting is already in the database using the UniqueIdentifier
                    Posting dbPosting = db.Postings.FirstOrDefault(m => m.UniqueIdentifier == seedPosting.UniqueIdentifier);

                    //if job posting is null, job posting is not in database
                    if (dbPosting == null)
                    {
                        //Add the job posting to the database
                        db.Postings.Add(seedPosting);
                        db.SaveChanges();
                    }
                    else //the job posting is in the database - reset all fields except ID and Unique Identifier
                    {
                        dbPosting.Title = seedPosting.Title;
                        dbPosting.Author = seedPosting.Author;
                        dbPosting.Views = seedPosting.Views;
                        dbPosting.PostedDate = seedPosting.PostedDate;
                        dbPosting.Summary = seedPosting.Summary;
                        dbPosting.Article = seedPosting.Article;
                        dbPosting.MinimumSalary = seedPosting.MinimumSalary;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex) //throw error if there is a problem in the database
            {
                StringBuilder msg = new StringBuilder();
                msg.Append("There was a problem adding the job posting with the title: ");
                msg.Append(strPostingTitle);
                msg.Append(" (JobPostingID: ");
                msg.Append(intPostingID);
                msg.Append(")");
                throw new Exception(msg.ToString(), ex);
            }
        
        }

    }
}