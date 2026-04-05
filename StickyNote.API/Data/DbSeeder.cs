namespace StickyNote.API.Data
{
    public static class DbSeeder
    {
        public static void Seed(StickyNoteDbContext context)
        {
            if (!context.Colours.Any())
            {
                context.Colours.AddRange(
                    new Models.Colour { Title = "Red", Code = "#EF9A9A" },
                    new Models.Colour { Title = "Green", Code = "#81C784" },
                    new Models.Colour { Title = "Blue", Code = "#64B5F6" },
                    new Models.Colour { Title = "Yellow", Code = "#FFEE58" },
                    new Models.Colour { Title = "Grey", Code = "#BDBDBD" },
                    new Models.Colour { Title = "Pink", Code = "#F48FB1" }
                );
                context.SaveChanges();
            }
        }
    }
}
