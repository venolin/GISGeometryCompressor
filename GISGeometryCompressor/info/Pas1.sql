--1 pass

DECLARE @g geography;

SET @g = geography::STPolyFromText('POLYGON ((18.689880000000002 -30.601900000000004, 18.689970000000006 -30.6021, 18.690660000000005 -30.602999999999998, 18.691240000000008 -30.601679999999998, 18.695430000000005 -30.60077, 18.692710000000005 -30.595950000000002, 18.691140000000008 -30.59291, 18.689960000000006 -30.590809999999998, 18.686670000000007 -30.59134, 18.686520000000005 -30.59049, 18.686780000000006 -30.58936, 18.685670000000009 -30.58841, 18.682560000000009 -30.58792, 18.681060000000009 -30.5877, 18.681180000000008 -30.58782, 18.683890000000009 -30.59008, 18.686040000000009 -30.59187, 18.686320000000009 -30.59232, 18.686630000000012 -30.59286, 18.687000000000012 -30.593470000000003, 18.68602000000001 -30.593940000000003, 18.68545000000001 -30.595990000000004, 18.684400000000007 -30.598280000000003, 18.681750000000005 -30.599750000000004, 18.689880000000002 -30.601900000000004))',4326);
SELECT @g; 