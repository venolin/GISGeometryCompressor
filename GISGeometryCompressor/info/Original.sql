--Original

DECLARE @g geography;

SET @g = geography::STPolyFromText('POLYGON ((18.689880000000002 -30.601900000000004, 18.689880000000006 -30.6019, 18.689970000000006 -30.6021, 18.689980000000006 -30.60298, 18.690660000000005 -30.602999999999998, 18.690710000000006 -30.601779999999998, 18.691240000000008 -30.601679999999998, 18.693440000000006 -30.60126, 18.695430000000005 -30.60077, 18.695370000000004 -30.60065, 18.692710000000005 -30.595950000000002, 18.691550000000007 -30.59373, 18.691140000000008 -30.59291, 18.690020000000008 -30.59077, 18.689960000000006 -30.590809999999998, 18.688810000000007 -30.591919999999998, 18.686670000000007 -30.59134, 18.686410000000006 -30.59116, 18.686520000000005 -30.59049, 18.686670000000007 -30.589859999999998, 18.686780000000006 -30.58936, 18.687020000000008 -30.58863, 18.685670000000009 -30.58841, 18.683990000000009 -30.58814, 18.682560000000009 -30.58792, 18.681770000000011 -30.5878, 18.681060000000009 -30.5877, 18.681080000000009 -30.58772, 18.681180000000008 -30.58782, 18.681900000000009 -30.58842, 18.683890000000009 -30.59008, 18.685010000000009 -30.59101, 18.686040000000009 -30.59187, 18.68629000000001 -30.59207, 18.686320000000009 -30.59232, 18.68648000000001 -30.59262, 18.686630000000012 -30.59286, 18.686830000000011 -30.593130000000002, 18.687000000000012 -30.593470000000003, 18.68695000000001 -30.593690000000002, 18.68602000000001 -30.593940000000003, 18.68564000000001 -30.594940000000005, 18.68545000000001 -30.595990000000004, 18.684930000000008 -30.597110000000004, 18.684400000000007 -30.598280000000003, 18.680860000000006 -30.599510000000002, 18.681750000000005 -30.599750000000004, 18.687500000000004 -30.601260000000003, 18.689880000000002 -30.601900000000004))',4326);
SELECT @g; 

--This
--0xE610000001043100000061764F1E169A3EC01C2AC6F99BB0324060764F1E169A3EC01D2AC6F99BB03240EEEBC039239A3EC09D38B9DFA1B032405F24B4E55C9A3EC0E4E47E87A2B03240ED7C3F355E9A3EC0C7A70018CFB032400A630B410E9A3EC02B05DD5ED2B0324043A852B3079A3EC0E4AFC91AF5B032409964E42CEC993EC0FFBCA94885B13240FD6A0E10CC993EC045A852B307B23240A857CA32C4993EC09A9EB0C403B232401C0DE02D90983EC0B89C4B7155B1324072A774B0FE973EC0808CB96B09B13240AB7823F3C8973EC01DF5108DEEB032403A75E5B33C973EC001969526A5B032405626FC523F973EC0568CF337A1B032402BD9B11188973EC0652827DA55B032400FD1E80E62973EC0F424E99AC9AF32400FB4024356973EC0BBA5D590B8AF3240739D465A2A973EC0C90C54C6BFAF3240F337A11001973EC0F424E99AC9AF32401092054CE0963EC0028C67D0D0AF3240C971A774B0963EC0ADB2EF8AE0AF3240ADA3AA09A2963EC02ED9B11188AF32402D78D15790963EC084CAF8F719AF324011AAD4EC81963EC0CC8E8D40BCAE3240BC96900F7A963EC0DB648D7A88AE3240F5DBD78173963EC0229DBAF259AE3240833463D174963EC0B0F545425BAE32404AEF1B5F7B963EC077B0FECF61AE3240F44F70B1A2963EC0772497FF90AE324010069E7B0F973EC0BD0F406A13AF3240E59B6D6E4C973EC0D96EBBD05CAF3240C87BD5CA84973EC075BF4351A0AF324056F146E691973EC0679291B3B0AF324048C49448A2973EC03C97E2AAB2AF32409DF4BEF1B5973EC0AE5B3D27BDAF3240481B47ACC5973EC0D973D2FBC6AF3240C846205ED7973EC067E94317D4AF32403A2861A6ED973EC0205A643BDFAF324056F65D11FC973EC0BCFC87F4DBAF324048C9AB730C983EC0E766B8019FAF32400F15E3FC4D983EC059D4601A86AF324039BEF6CC92983EC0120BB5A679AF3240551D7233DC983EC0A00C8E9257AF3240D4D9C9E028993EC0E761A1D634AF3240FE9FC37C79993EC0932749D74CAE3240A9C64B3789993EC04B0C022B87AE32409A64E42CEC993EC00100000000B0324061764F1E169A3EC01C2AC6F99BB0324001000000020000000001000000FFFFFFFF0000000003

--Original
--0x000000000104310000001C2AC6F99BB0324061764F1E169A3EC01D2AC6F99BB0324060764F1E169A3EC09D38B9DFA1B03240EEEBC039239A3EC0E4E47E87A2B032405F24B4E55C9A3EC0C7A70018CFB03240ED7C3F355E9A3EC02B05DD5ED2B032400A630B410E9A3EC0E4AFC91AF5B0324043A852B3079A3EC0FFBCA94885B132409964E42CEC993EC045A852B307B23240FD6A0E10CC993EC09A9EB0C403B23240A857CA32C4993EC0B89C4B7155B132401C0DE02D90983EC0808CB96B09B1324072A774B0FE973EC01DF5108DEEB03240AB7823F3C8973EC001969526A5B032403A75E5B33C973EC0568CF337A1B032405626FC523F973EC0652827DA55B032402BD9B11188973EC0F424E99AC9AF32400FD1E80E62973EC0BBA5D590B8AF32400FB4024356973EC0C90C54C6BFAF3240739D465A2A973EC0F424E99AC9AF3240F337A11001973EC0028C67D0D0AF32401092054CE0963EC0ADB2EF8AE0AF3240C971A774B0963EC02ED9B11188AF3240ADA3AA09A2963EC084CAF8F719AF32402D78D15790963EC0CC8E8D40BCAE324011AAD4EC81963EC0DB648D7A88AE3240BC96900F7A963EC0229DBAF259AE3240F5DBD78173963EC0B0F545425BAE3240833463D174963EC077B0FECF61AE32404AEF1B5F7B963EC0772497FF90AE3240F44F70B1A2963EC0BD0F406A13AF324010069E7B0F973EC0D96EBBD05CAF3240E59B6D6E4C973EC075BF4351A0AF3240C87BD5CA84973EC0679291B3B0AF324056F146E691973EC03C97E2AAB2AF324048C49448A2973EC0AE5B3D27BDAF32409DF4BEF1B5973EC0D973D2FBC6AF3240481B47ACC5973EC067E94317D4AF3240C846205ED7973EC0205A643BDFAF32403A2861A6ED973EC0BCFC87F4DBAF324056F65D11FC973EC0E766B8019FAF324048C9AB730C983EC059D4601A86AF32400F15E3FC4D983EC0120BB5A679AF324039BEF6CC92983EC0A00C8E9257AF3240551D7233DC983EC0E761A1D634AF3240D4D9C9E028993EC0932749D74CAE3240FE9FC37C79993EC04B0C022B87AE3240A9C64B3789993EC00100000000B032409A64E42CEC993EC01C2AC6F99BB0324061764F1E169A3EC001000000020000000001000000FFFFFFFF0000000003