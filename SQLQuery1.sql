select * from Routes
select * from PointsList
select * from Points

select Routes.Name, Points.Name, Points.location from Routes, PointsList, Points
where Routes.IdRoute = PointsList.IdRoute and PointsList.IdPoint = Points.IdPoint
order by Routes.Name