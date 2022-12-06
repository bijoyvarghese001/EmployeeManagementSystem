CREATE TABLE TimeSheet(StartDate date, EndDate date, EmpId int, Mon float, Tue float, Wed float, Thu float, Fri float, Sat float, Sun float)

--DROP TABLE TimeSheet
SELECT * FROM TimeSheet


INSERT INTO TimeSheet
VALUES('2022-11-27','2022-12-03' , 102, 7.5 ,8.3 ,5.7 ,7.6 ,6.8 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-04','2022-12-10' , 102, 7 ,8.3 ,5.7 ,0.0 ,0.0 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-11','2022-12-17' , 102, 0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 );

INSERT INTO TimeSheet
VALUES('2022-11-27','2022-12-03' , 103, 8 , 6.2, 5.3 ,5.6 ,8.5 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-04','2022-12-10' , 103, 8 ,7.59, 7.25 ,0.0 ,0.0 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-11','2022-12-17' , 103, 0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 );

INSERT INTO TimeSheet
VALUES('2022-11-27','2022-12-03' , 105, 6 , 8.2, 4.9 ,7 ,8 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-04','2022-12-10' , 105, 7.8 ,7, 8 ,0.0 ,0.0 ,0.0 ,0.0 );
INSERT INTO TimeSheet
VALUES('2022-12-11','2022-12-17' , 105, 0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 ,0.0 );