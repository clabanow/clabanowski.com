--migrating CLabanowski website to new server

CREATE TABLE [dbo].[BlogPosts] (
    [Id]        INT            NOT NULL,
    [Title]     NVARCHAR (MAX) NULL,
    [Text]      NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NOT NULL,
    [RouteName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.BlogPosts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[PortfolioProjects] (
    [Id]           INT            NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Technologies] NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [LinkUrl]      NVARCHAR (MAX) NULL,
    [ImgUrl]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.PortfolioProjects] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[IdentityUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (MAX) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,


    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.IdentityUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[IdentityRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.IdentityRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[IdentityUserRoles] (
    [RoleId]          NVARCHAR (128) NOT NULL,
    [UserId]          NVARCHAR (128) NOT NULL,
    [IdentityUser_Id] NVARCHAR (128) NULL,
    [IdentityRole_Id] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.IdentityUserRoles] PRIMARY KEY CLUSTERED ([RoleId] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityUsers_IdentityUser_Id] FOREIGN KEY ([IdentityUser_Id]) REFERENCES [dbo].[IdentityUsers] ([Id]),
    CONSTRAINT [FK_dbo.IdentityUserRoles_dbo.IdentityRoles_IdentityRole_Id] FOREIGN KEY ([IdentityRole_Id]) REFERENCES [dbo].[IdentityRoles] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_IdentityUser_Id]
    ON [dbo].[IdentityUserRoles]([IdentityUser_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IdentityRole_Id]
    ON [dbo].[IdentityUserRoles]([IdentityRole_Id] ASC);

INSERT INTO [dbo].[BlogPosts] ([Id], [Title], [Text], [Date], [RouteName]) VALUES (1, N'SWC Guild Precap', N'<p>Tomorrow is my first day the at Software Craftsmanship Guild in Akron, Ohio. I&#39;ll be blogging weekly over the course of the program (3 months) in order to both organize my thoughts and track my progress and also to provide information for others who are considering a similar path.</p>

<p>&nbsp;</p>

<p>First, I would like to talk about my motivations in pursuing software development, then explain why I chose the&nbsp;<a href="http://www.swcguild.com/" target="_blank">SWC Guild</a>, and finally I will conclude with my hopes and expectations for the program.</p>

<p>&nbsp;</p>

<p>For the past 3.5 years I have worked for a EUR 3bn&nbsp;<a href="http://en.wikipedia.org/wiki/Equity_(finance)">equity investment</a>&nbsp;fund within the Dutch investment giant,&nbsp;<a href="https://www.pggm.nl/english/Pages/default.aspx" target="_blank">PGGM</a>. As the person responsible for all of our technology investments (amounting to around EUR 500m), I spent my days and nights learning about various hardware and software technologies, markets, and companies, and making investment decisions accordingly. Since all investment is fundamentally about the future, I spent most of my time working out various models about how the future of technology would evolve and how that would effect global business.</p>

<p>&nbsp;</p>

<p>I came to the same general conclusion that many others already have: that&nbsp;<a href="http://online.wsj.com/news/articles/SB10001424053111903480904576512250915629460" target="_blank">software is eating the world</a>, multiple industries at a time. To put it another way, all of business is about one person (or company) providing value for another, and increasingly software is becoming a bigger and bigger part of the &quot;value pie.&quot; That means money and jobs and, to some extent, more control over one&#39;s life. It also means that software will probably play a leading role in trying solve some of the most interesting problems of the future.</p>

<p>&nbsp;</p>

<p>So the software industry appears to be a long term winner with a lot of interesting problems to be solved. That&#39;s great in a theoretical sense, but practically speaking, to take up a completely new career at 25 as I am trying to do, the main question is: do you enjoy it? This may seem like a typically-Millenial questions, loaded with a sense of entitlement, but to even approach the level of decent software developer, you are going to have to devote thousands of hours to building up your skills, and many of those will be coated in frustration. While the uncertain prospect of future riches may motivate some, I am not strong enough for that, so I would have to enjoy what I&#39;m doing (most of the time, at least) in order to power through the muck to reach the promised land.</p>

<p>&nbsp;</p>

<p>And over the past 6 months, I have found out with resounding certainty that I do really like to write code. There are many reasons but the biggest are:</p>

<ul>
	<li>Coding&nbsp;works&nbsp;your brain. This can be both fun and maddening; the computer and highly capable and highly dumb - everything depends on you, so there are no excuses, just your brain power and perseverance. I&#39;ve never felt such satisfaction when I (finally) get it right, even when creating the most trivial things.</li>
	<li>Coding is often perfectly suited to achieving a state of&nbsp;<a href="http://en.wikipedia.org/wiki/Flow_(psychology)" target="_blank">flo</a><a href="http://en.wikipedia.org/wiki/Flow_(psychology)" target="_blank">w</a>.&nbsp;You get immediate confirmation (one way or the other) of your work, and if you choose the right problems to tackle, programming can often fall in that perfect sweet spot that is juuust outside your competency level which challenges you, keeps you fully engrossed in the task at hand, and gives you the exhilaration of seeing the growth of your skills right in front of your eyes.</li>
	<li>Each new thing you learn leads to multiple other, more powerful things that are begging to be learned, too.&nbsp;This, together with flow, make for a pretty addictive experience at times. There is always more to learn, and it&#39;s tantalizingly sitting there, just waiting for you to put in the time to learn and implement it.</li>
	<li>Learning how the web works is a gradually enlightening experience punctuated by rare, but mind-blowing &quot;aha moments.&quot;&nbsp;I&#39;ve used the web for as long as I can remember, but only recently have I begun to understand it, which makes it both more awe-inspiring and enjoyable.</li>
</ul>

<p>&nbsp;</p>

<p>Knowing that I wanted to get into software development, the question then became, &quot;what&#39;s the best way to do it?&quot; Being a late bloomer, efficiency and commercial-mindedness would be key, and going to one of the many bootcamp-style courses seemed like the best choice. Even though they are not cheap (at around USD 10k per 9-12 week session), it seems like the structured, group environment, led by a competent teacher, would in the end by a good investment versus self-directed online learning. There is so much out there, and there is a lot of value in being told by a professional which mini-path to take each day when you are starting.</p>

<p>&nbsp;</p>

<p>I ended up choosing the SWC Guild for four main reasons. First, it had gotten very positive reviews from past students, most of whom had found development jobs. I realize positive online reviews can be self-selecting, but these seemed genuine and were, in fact, not universally positive.</p>

<p>&nbsp;</p>

<p>Second, I was impressed by what I had heard (both first- and secondhand) about Eric Wise, the head of the SWC Guild. He seemed an honest guy, with a solid track record both professionally and as a teacher, and, importantly, he comes off as a good communicator. He&#39;s also not overly self-promotional, and does not seem to be getting into the coding bootcamp business primarily to get rich quick off the burgeoning &quot;learn to code&quot; trend/bubble.</p>

<p>&nbsp;</p>

<p>Third, the SWC Guild has small class sizes, typically around 8 people. If I am going to take the financial and professional risk that learning to code entails, I don&#39;t want to be just another anonymous student; I want the teacher to take some stake in my learning, which means a lot of face-to-face time. This is only possible in a small group.</p>

<p>&nbsp;</p>

<p>And finally (and least importantly), I liked that the&nbsp;SWC Guild offered a course in C# instead of Ruby. I have no doubt that Ruby (and Rails) is a fantastic and powerful language; I just prefer to be one of 20-30 new C# programmers coming out of coding bootcamps per year rather than the 500+ that are coming out of Ruby ones. In the end, everyone says that language matters far less to the beginning programmer than fundamentals and good habits, but in terms of finding a job post-graduation, this also seemed appealing (especially as I am at this point more attracted to enterprise, rather than consumer, software).</p>

<p>&nbsp;</p>

<p>Looking ahead to the next 12 weeks, there are four main things I&#39;m expecting the get out of the program. &nbsp;The first and most practical is that I want to be employable for a wide range of companies in an entry-level software developer position. I realize that there is only so much you can learn in 12 weeks, and that the real learning and growing will happen on the job, so this one is key (although impossible to tell until after-the-fact).</p>

<p>&nbsp;</p>

<p>Second, I want to learn what I need to learn. There is so much out there, and as a beginner it is hard to know where to start in building something, what is worth spending time on, etc. I hope to get a structured way of thinking about problem solving (and how to solve new problems that I have no encountered before) that I can then use on a range of software projects.</p>

<p>&nbsp;</p>

<p>Third, I want to have the building blocks to build a (simple) end-to-end web application. This is a powerful and exciting prospect in itself, and once I can do this, I can have a solid framework post-graduation for building up my skills in all the related aspects of web developments.</p>

<p>&nbsp;</p>

<p>Finally, I want to start to understand why to use one technology or method over another. Perhaps this is asking too much, but at this point I do not have the knowledge to understand why most things are done one way instead of the other. This seems like a particularly crucial aspect of becoming a good developer, so I want to start asking these questions (and hopefully getting answers) early.</p>

<p>&nbsp;</p>

<p>We shall see how this all pans out over the next 12 weeks. It is sure to be a fun and intense time.</p>
', N'2014-01-05 00:00:00', N'swc-guild-precap')


INSERT INTO [dbo].[IdentityRoles] ([Id], [Name]) VALUES (N'1', N'admin')
INSERT INTO [dbo].[IdentityRoles] ([Id], [Name]) VALUES (N'2', N'guest')

INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1bf71533-cfd0-475b-a6a3-7da07cb5ce0f', NULL, 0, N'AN0ympbl7BOw+tKRc2e2EF/yLEb3t0SzSeY/G+IljxjxmvC25mAxIk7fE66oehG3xQ==', N'cd76244b-8c82-4926-8ec8-4821043667a8', NULL, 0, 0, NULL, 0, 0, N'william')
INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'80d93dd0-4210-4b34-a206-37135db4584a', NULL, 0, N'AGLBhhDXwgQwqJNWiguy7JdbA2OwqvmBUfGdTDuqSFQNbYiBbE6ba1cZOKWTTIfKzQ==', N'3773f981-5b4c-4f22-9f7a-15cbadf1eb25', NULL, 0, 0, NULL, 0, 0, N'charles')
INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90e86e9a-a451-4d7c-b0cd-462a691de3ad', NULL, 0, N'AKZyQVSCRI168A4elfsc91ZGYbxE/K3Y5Bu+71OXYnf1zlxoRnYr2Av8vQRByyNwsg==', N'646dddcf-bee5-4831-a8f0-fd185b25f26a', NULL, 0, 0, NULL, 0, 0, N'clabanow')
INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b871227d-6da3-4958-8a5c-12454a5eb05d', NULL, 0, N'ANsKuUSQQGPXnyBpaeieAXLeB+X+MILUsnZvFWMuKonJ3gncvpktitbRwW0TFYiF8g==', N'05342e96-ea41-4741-831e-4f57ceacde30', NULL, 0, 0, NULL, 0, 0, N'helloworld')

INSERT INTO [dbo].[IdentityUserRoles] ([RoleId], [UserId], [IdentityUser_Id], [IdentityRole_Id]) VALUES (N'1', N'b871227d-6da3-4958-8a5c-12454a5eb05d', N'b871227d-6da3-4958-8a5c-12454a5eb05d', N'1')

INSERT INTO [dbo].[PortfolioProjects] ([Id], [Name], [Technologies], [Description], [LinkUrl], [ImgUrl]) VALUES (1, N'FutureCodr', N'C#,ASP.NET MVC,Javascript,AngularJS,HTML,CSS,Ninject,Dapper,nUnit,Entity Framework', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tristique eget justo sit amet eleifend. Quisque quis dignissim ante. Vestibulum sit amet tincidunt libero. Nunc volutpat consectetur diam a porttitor. Sed ut lectus elit. Vivamus vehicula massa pellentesque sem porttitor sodales. Duis libero nibh, tincidunt ac posuere eu, ', N'http:www.futurecodr.com', N'/Content/thumbnails/Futurecodr_tn.png')
INSERT INTO [dbo].[PortfolioProjects] ([Id], [Name], [Technologies], [Description], [LinkUrl], [ImgUrl]) VALUES (2, N'clabanowski.com', N'C#,ASP.NET MVC,SQL Server,Dapper,Entity Framework,Moq,HTML,CSS', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tristique eget justo sit amet eleifend. Quisque quis dignissim ante. Vestibulum sit amet tincidunt libero. Nunc volutpat consectetur diam a porttitor. Sed ut lectus elit. Vivamus vehicula massa pellentesque sem porttitor sodales. Duis libero nibh, tincidunt ac posuere eu Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tristique eget justo sit amet eleifend. Quisque quis dignissim ante. Vestibulum sit amet tincidunt libero. Nunc volutpat consectetur diam a porttitor. ', N'http://www.espn.com', N'/Content/thumbnails/Clabanowski_tn.png')

