--3 pass

DECLARE @g geography;

SET @g = geography::STPolyFromText('POLYGON ((18.689880000000002 -30.601900000000004, 18.695430000000005 -30.60077, 18.686670000000007 -30.59134, 18.682560000000009 -30.58792, 18.686040000000009 -30.59187, 18.68602000000001 -30.593940000000003, 18.689880000000002 -30.601900000000004))',4326);
SELECT @g; 