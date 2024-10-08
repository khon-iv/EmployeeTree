USE [CompanyNameDataBase]
GO
DELETE FROM [dbo].[Employees];
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (1, N'Сумкина Диана Владимировна', N'Генеральный директор', 0, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (2, N'Шрек Болотный Огр', N'Заместитель директора', 1, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (3, N'Принцесса Фиона', N'Главный бухгалтер', 2, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (4, N'Кот в сапогах', N'Главный юрист', 2, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (5, N'Осел', N'Нальник отдела кадров', 2, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (6, N'Фелиция Болотный Огр', N'Бухгалтер', 3, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (7, N'Фергус Болотный Огр', N'Бухгалтер', 3, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (8, N'Фаркл Болотный Огр', N'Бухгалтер', 3, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (9, N'Дракониха', N'Сотрудник отдела кадров', 5, 0)

INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (10, N'Алекс', N'Заместитель директора', 1, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (11, N'Марти', N'Руководитель отдела развития', 10, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (12, N'Глория', N'Менеджер', 10, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (13, N'Король Лемуров Джулиан', N'Король', 10, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (14, N'Мелман', N'Штатный врач', 12, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (15, N'Мото-Мото', N'Грузчик', 12, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (16, N'Морт', N'Помошник', 13, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (17, N'Морис', N'Секретарь', 13, 0)

INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (18, N'Шкипер', N'Заместитель директора по безопасности', 1, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (19, N'Ковальский', N'Инженер', 18, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (20, N'Рико', N'Подрывник', 18, 0)
INSERT [dbo].[Employees] ([Id], [FullName], [Position], [HeadId], [Marked]) VALUES (21, N'Рядовой Прапор', N'Стажер', 18, 0)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
