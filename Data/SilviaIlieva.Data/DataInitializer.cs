namespace SilviaIlieva.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using SilviaIlieva.Data.Models;

    public static class DataInitializer
    {
        public static void SeedAdministrator(ModelBuilder builder, IConfiguration configuration)
        {
            var userId = "9B5FA88B-48C2-435B-B140-5212E669A34B";
            var roleId = "0909A2A6-81A1-4074-B7F8-C0DC4E7392AB";

            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = roleId,
                    Name = "Administrator",
                    NormalizedName = "Administrator".ToUpper()
                });

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User()
                {
                    Id = userId,
                    UserName = configuration["Username"],
                    NormalizedUserName = configuration["Username"].ToUpper(),
                    PasswordHash = hasher.HashPassword(null, configuration["Password"]),
                    SecurityStamp = string.Empty
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = userId,
                    RoleId = roleId
                });
        }

        public static void SeedUtilityData(ModelBuilder builder)
        {
            builder.Entity<UtilityData>().HasData(
            new UtilityData()
            {
                Id = 1,
                IsDeleted = false,
                Name = "About",
                Value = @"
<h1>About me</h1>
<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pharetra tellus eu dolor convallis faucibus. Quisque hendrerit, orci a sodales convallis, neque justo venenatis diam, vitae semper mauris metus vitae nulla. Etiam at est convallis, ultrices odio in, sagittis libero. Praesent id lorem molestie, commodo ex sit amet, feugiat neque. Sed interdum metus a arcu dapibus suscipit. Vestibulum cursus vitae eros et dapibus. Fusce volutpat commodo ante tempus placerat. Nulla congue leo ac lectus vestibulum, at cursus elit vulputate. Sed pharetra faucibus ante. Donec fringilla orci ut hendrerit vulputate. Phasellus vel lectus ac turpis scelerisque vehicula eget dapibus dolor.</p>
<p>Nulla sit amet mi suscipit, finibus sapien eu, porttitor nulla. Mauris pretium fermentum lorem, ut tincidunt mi sodales vestibulum. Quisque et dapibus dui, eu feugiat enim. Nullam laoreet laoreet tellus, in tempus massa vestibulum eget. Donec pretium elit eu justo egestas congue. Morbi eget quam congue, hendrerit mauris sit amet, accumsan tortor. Phasellus urna lorem, elementum a massa id, dictum facilisis nisl. Nullam tempor laoreet tincidunt. Vivamus et bibendum enim, a sagittis urna. Aenean elementum vel risus a sodales. Integer fringilla interdum orci, at fringilla justo rutrum vitae. Nulla facilisis pretium lacus, quis efficitur diam venenatis at. Nulla ultrices ullamcorper sem, ac accumsan arcu.</p>
<p>Morbi dictum et arcu a congue. In a nibh quis justo aliquet luctus. Praesent volutpat neque malesuada leo efficitur, eu tristique velit varius. In non nibh eleifend, porttitor enim sed, bibendum tortor. Quisque posuere sapien vel efficitur interdum. Maecenas cursus, mi eget aliquet egestas, est felis vestibulum nisi, ac gravida lectus augue eget purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque ornare diam turpis, in molestie justo tempus in. Integer porta condimentum varius. Aliquam rutrum mauris non augue accumsan vulputate. In feugiat lorem massa, non sollicitudin massa porta sed. Donec sapien lectus, scelerisque auctor tempus nec, fermentum ac velit. Fusce ac rutrum neque, quis commodo lacus. Vestibulum condimentum scelerisque tellus ac mattis. Aenean tellus nunc, feugiat ut leo maximus, viverra tincidunt ligula.</p>
<p>Integer id condimentum dui, a porttitor ex. Ut commodo tortor eget nulla imperdiet dignissim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam faucibus arcu sit amet vehicula sodales. Nullam at congue nibh, ac aliquet elit. Praesent ut turpis interdum, dictum lorem in, luctus nibh. Etiam dignissim tincidunt sem, quis dictum ipsum aliquam ac. Integer consequat non tortor eget condimentum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed commodo porttitor lacus a elementum. Praesent imperdiet sodales convallis. Vestibulum consectetur nulla lectus, ut ultrices ipsum pellentesque quis.</p>"
            },
            new UtilityData()
            {
                Id = 2,
                IsDeleted = false,
                Name = "Disclaimer",
                Value = @"
<h1>Disclaimer</h1>
<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pharetra tellus eu dolor convallis faucibus. Quisque hendrerit, orci a sodales convallis, neque justo venenatis diam, vitae semper mauris metus vitae nulla. Etiam at est convallis, ultrices odio in, sagittis libero. Praesent id lorem molestie, commodo ex sit amet, feugiat neque. Sed interdum metus a arcu dapibus suscipit. Vestibulum cursus vitae eros et dapibus. Fusce volutpat commodo ante tempus placerat. Nulla congue leo ac lectus vestibulum, at cursus elit vulputate. Sed pharetra faucibus ante. Donec fringilla orci ut hendrerit vulputate. Phasellus vel lectus ac turpis scelerisque vehicula eget dapibus dolor.</p>
<p>Nulla sit amet mi suscipit, finibus sapien eu, porttitor nulla. Mauris pretium fermentum lorem, ut tincidunt mi sodales vestibulum. Quisque et dapibus dui, eu feugiat enim. Nullam laoreet laoreet tellus, in tempus massa vestibulum eget. Donec pretium elit eu justo egestas congue. Morbi eget quam congue, hendrerit mauris sit amet, accumsan tortor. Phasellus urna lorem, elementum a massa id, dictum facilisis nisl. Nullam tempor laoreet tincidunt. Vivamus et bibendum enim, a sagittis urna. Aenean elementum vel risus a sodales. Integer fringilla interdum orci, at fringilla justo rutrum vitae. Nulla facilisis pretium lacus, quis efficitur diam venenatis at. Nulla ultrices ullamcorper sem, ac accumsan arcu.</p>
<p>Morbi dictum et arcu a congue. In a nibh quis justo aliquet luctus. Praesent volutpat neque malesuada leo efficitur, eu tristique velit varius. In non nibh eleifend, porttitor enim sed, bibendum tortor. Quisque posuere sapien vel efficitur interdum. Maecenas cursus, mi eget aliquet egestas, est felis vestibulum nisi, ac gravida lectus augue eget purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque ornare diam turpis, in molestie justo tempus in. Integer porta condimentum varius. Aliquam rutrum mauris non augue accumsan vulputate. In feugiat lorem massa, non sollicitudin massa porta sed. Donec sapien lectus, scelerisque auctor tempus nec, fermentum ac velit. Fusce ac rutrum neque, quis commodo lacus. Vestibulum condimentum scelerisque tellus ac mattis. Aenean tellus nunc, feugiat ut leo maximus, viverra tincidunt ligula.</p>
<p>Integer id condimentum dui, a porttitor ex. Ut commodo tortor eget nulla imperdiet dignissim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam faucibus arcu sit amet vehicula sodales. Nullam at congue nibh, ac aliquet elit. Praesent ut turpis interdum, dictum lorem in, luctus nibh. Etiam dignissim tincidunt sem, quis dictum ipsum aliquam ac. Integer consequat non tortor eget condimentum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed commodo porttitor lacus a elementum. Praesent imperdiet sodales convallis. Vestibulum consectetur nulla lectus, ut ultrices ipsum pellentesque quis.</p>"
            },
            new UtilityData()
            {
                Id = 3,
                IsDeleted = false,
                Name = "Cookies",
                Value = @"
<h1>Cookies</h1>
<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pharetra tellus eu dolor convallis faucibus. Quisque hendrerit, orci a sodales convallis, neque justo venenatis diam, vitae semper mauris metus vitae nulla. Etiam at est convallis, ultrices odio in, sagittis libero. Praesent id lorem molestie, commodo ex sit amet, feugiat neque. Sed interdum metus a arcu dapibus suscipit. Vestibulum cursus vitae eros et dapibus. Fusce volutpat commodo ante tempus placerat. Nulla congue leo ac lectus vestibulum, at cursus elit vulputate. Sed pharetra faucibus ante. Donec fringilla orci ut hendrerit vulputate. Phasellus vel lectus ac turpis scelerisque vehicula eget dapibus dolor.</p>
<p>Nulla sit amet mi suscipit, finibus sapien eu, porttitor nulla. Mauris pretium fermentum lorem, ut tincidunt mi sodales vestibulum. Quisque et dapibus dui, eu feugiat enim. Nullam laoreet laoreet tellus, in tempus massa vestibulum eget. Donec pretium elit eu justo egestas congue. Morbi eget quam congue, hendrerit mauris sit amet, accumsan tortor. Phasellus urna lorem, elementum a massa id, dictum facilisis nisl. Nullam tempor laoreet tincidunt. Vivamus et bibendum enim, a sagittis urna. Aenean elementum vel risus a sodales. Integer fringilla interdum orci, at fringilla justo rutrum vitae. Nulla facilisis pretium lacus, quis efficitur diam venenatis at. Nulla ultrices ullamcorper sem, ac accumsan arcu.</p>
<p>Morbi dictum et arcu a congue. In a nibh quis justo aliquet luctus. Praesent volutpat neque malesuada leo efficitur, eu tristique velit varius. In non nibh eleifend, porttitor enim sed, bibendum tortor. Quisque posuere sapien vel efficitur interdum. Maecenas cursus, mi eget aliquet egestas, est felis vestibulum nisi, ac gravida lectus augue eget purus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque ornare diam turpis, in molestie justo tempus in. Integer porta condimentum varius. Aliquam rutrum mauris non augue accumsan vulputate. In feugiat lorem massa, non sollicitudin massa porta sed. Donec sapien lectus, scelerisque auctor tempus nec, fermentum ac velit. Fusce ac rutrum neque, quis commodo lacus. Vestibulum condimentum scelerisque tellus ac mattis. Aenean tellus nunc, feugiat ut leo maximus, viverra tincidunt ligula.</p>
<p>Integer id condimentum dui, a porttitor ex. Ut commodo tortor eget nulla imperdiet dignissim. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam faucibus arcu sit amet vehicula sodales. Nullam at congue nibh, ac aliquet elit. Praesent ut turpis interdum, dictum lorem in, luctus nibh. Etiam dignissim tincidunt sem, quis dictum ipsum aliquam ac. Integer consequat non tortor eget condimentum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed commodo porttitor lacus a elementum. Praesent imperdiet sodales convallis. Vestibulum consectetur nulla lectus, ut ultrices ipsum pellentesque quis.</p>"
            });
        }
    }
}
