namespace mr_mat_api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public long PinCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Notification { get; set; }
        public int WorkLocationDistance { get; set; }
        public bool IsPrivate { get; set; }
    }
}

/* 
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[PinCode] [bigint] NULL,
	[Mobile] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[DateOfBirth] [date] NULL,
	[Notification] [varchar](50) NULL,
	[WorkLocationDistance] [int] NULL,
	[IsPrivate] [bit] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

*/