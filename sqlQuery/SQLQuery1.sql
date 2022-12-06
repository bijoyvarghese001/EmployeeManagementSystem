CREATE TABLE TimeSheet(StartDate date, EndDate date, EmpId int, Mon float, Tue float, Wed float, Thu float, Fri float, Sat float, Sun float)
INSERT INTO TimeSheet
VALUES('2022-11-27','2022-12-03' , 101, 7.5 ,8.3 ,5.7 ,7.6 ,6.8 ,0.0 ,0.0 );
--DROP TABLE TimeSheet
SELECT * FROM TimeSheet
INSERT INTO TimeSheet
VALUES('2022-12-04','2022-12-10' , 100, 7 ,8.3 ,5.7 ,7.2 ,6.8 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-04','2022-12-10' , 101, 7.8 ,8 ,5.3 ,7.2 ,6.8 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-11','2022-12-17' , 101, 0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 );