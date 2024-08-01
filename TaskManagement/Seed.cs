using TaskManagement.Database;
using TaskManagement.Models;

namespace TaskManagement
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Projects.Any() || !dataContext.Tasks.Any() || !dataContext.Activities.Any())
            {
                var projects = new List<Project>
                {
                    new Project
                    {
                        Project_Name = "Web Development",
                        Tasks = new List<Tasks>
                        {
                            new Tasks
                            {
                                Task_Name = "Design UI",
                                Activities = new List<Activity>
                                {
                                    new Activity
                                    {
                                        Act_Name = "Create Mockups",
                                        Act_Date = DateTime.UtcNow, // Use UTC time
                                        Act_ImagePath = "mockups/mockup1.jpg" // 
                                    },
                                    new Activity
                                    {
                                        Act_Name = "Create Wireframes",
                                        Act_Date = DateTime.UtcNow.AddDays(1),
                                        Act_ImagePath = "wireframes/wireframe1.jpg" // 
                                    }
                                }
                            },
                            new Tasks
                            {
                                Task_Name = "Implement Backend",
                                Activities = new List<Activity>
                                {
                                    new Activity
                                    {
                                        Act_Name = "Set up Database",
                                        Act_Date = DateTime.UtcNow,
                                        Act_ImagePath = "database/setup.jpg" // 
                                    },
                                    new Activity
                                    {
                                        Act_Name = "Implement API Endpoints",
                                        Act_Date = DateTime.UtcNow.AddDays(1),
                                        Act_ImagePath = "api/endpoints.jpg" // 
                                    }
                                }
                            }
                        }
                    },
                    new Project
                    {
                        Project_Name = "Mobile App",
                        Tasks = new List<Tasks>
                        {
                            new Tasks
                            {
                                Task_Name = "Develop iOS App",
                                Activities = new List<Activity>
                                {
                                    new Activity
                                    {
                                        Act_Name = "Design UX",
                                        Act_Date = DateTime.UtcNow,
                                        Act_ImagePath = "ux/design.jpg" // 
                                    },
                                    new Activity
                                    {
                                        Act_Name = "Implement Core Features",
                                        Act_Date = DateTime.UtcNow.AddDays(1),
                                        Act_ImagePath = "features/feature1.jpg" // 
                                    }
                                }
                            },
                            new Tasks
                            {
                                Task_Name = "Test and Debug",
                                Activities = new List<Activity>
                                {
                                    new Activity
                                    {
                                        Act_Name = "Perform Unit Testing",
                                        Act_Date = DateTime.UtcNow,
                                        Act_ImagePath = "testing/unit.jpg" // 
                                    },
                                    new Activity
                                    {
                                        Act_Name = "Debug Issues",
                                        Act_Date = DateTime.UtcNow.AddDays(1),
                                        Act_ImagePath = "debugging/issue1.jpg" //
                                    }
                                }
                            }
                        }
                    }
                };

                dataContext.Projects.AddRange(projects);
                dataContext.SaveChanges();
            }
        }
    }
}