--INSERT INTO [dbo].[student] ([First_Name], [Last_Name], [DOB], [Weight], [Height])
--VALUES ('John', 'Doe', '1956-02-09', 160, 64)

--SELECT [StudentID],[First_Name],[Last_Name],[DOB],[Weight],[Height]
--FROM [PROG455FA23].[dbo].[Student]

--INSERT INTO [dbo].[student] ([First_Name], [Last_Name], [DOB], [Weight], [Height])
--VALUES ('Jane', 'Doe', '1990-07-24', 140, 60)

--INSERT INTO [dbo].[Student] ([First_Name], [Last_Name], [DOB], [Weight], [Height])
--VALUES ('Bill', 'Preston', '1989-03-04', 144, 60)

--INSERT INTO [dbo].[student] ([First_Name], [Last_Name], [DOB], [Weight], [Height])
--VALUES ('Sam', 'Johnson', '2000-08-24', 143, 60)

--INSERT INTO [dbo].[student] ([First_Name], [Last_Name], [DOB], [Weight], [Height])
--VALUES ('Nick', 'Eisner', '2002-01-16', 145, 60)

/*
SELECT [StudentID],[First_Name],[Last_Name],[DOB],[Weight],[Height]
FROM [PROG455FA23].[dbo].[Student]
Where StudentID = 2 OR First_Name = 'John'
*/

--UPDATE [PROG455FA23].[dbo].[Student]
--SET First_Name = 'Jane', Last_Name = 'Doe' WHERE StudentID = 1

--DELETE FROM [dbo].[Student] WHERE StudentID = 4

SELECT * from Student