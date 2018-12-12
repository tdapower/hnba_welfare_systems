CREATE OR REPLACE PROCEDURE INSERT_WELF_TSHIRT(
  V_COMPANY            VARCHAR2,
  V_EPF_NO             NUMBER,
  V_CONSENT            VARCHAR2,
  V_NO_OF_ITEMS 		 NUMBER,
  V_REMARK            VARCHAR2,
  V_G_EX_SMALL	NUMBER,
  V_G_SMALL		NUMBER,
  V_G_MEDIUM	NUMBER,
  V_G_LARGE	NUMBER,
  V_G_EX_LARGE	NUMBER,
  V_G_DEX_LARGE	NUMBER,
  V_L_EX_SMALL	NUMBER,
  V_L_SMALL		NUMBER,
  V_L_MEDIUM	NUMBER,
  V_L_LARGE	NUMBER,
  V_L_EX_LARGE	NUMBER,
  V_L_DEX_LARGE	NUMBER
)
IS 
       

BEGIN
     DELETE FROM WELF_TSHIRT WHERE COMPANY =V_COMPANY AND EPF_NO=V_EPF_NO;
	  
      INSERT INTO  WELF_TSHIRT
      (
		  COMPANY   ,
		  EPF_NO     ,
		  CONSENT    ,
		  NO_OF_ITEMS ,
		  SYSTEM_DATE    ,
		  REMARKS		, 
		  G_EX_SMALL	,		  
		  G_SMALL		,
		  G_MEDIUM	,
		  G_LARGE	,
		  G_EX_LARGE	,
		  G_DEX_LARGE	,
		  L_EX_SMALL	,
		  L_SMALL		,
		  L_MEDIUM	,
		  L_LARGE	,
		  L_EX_LARGE	,
		  L_DEX_LARGE	
		  
      )
      VALUES
      (
		  V_COMPANY   ,
		  V_EPF_NO    ,
		  V_CONSENT   ,
		  V_NO_OF_ITEMS 	,
		  SYSDATE        ,
		  V_REMARK,
		    V_G_EX_SMALL	,
		  V_G_SMALL		,
		  V_G_MEDIUM	,
		  V_G_LARGE	,
		  V_G_EX_LARGE	,
		  V_G_DEX_LARGE	,
		  V_L_EX_SMALL	,
		  V_L_SMALL		,
		  V_L_MEDIUM	,
		  V_L_LARGE	,
		  V_L_EX_LARGE	,
		  V_L_DEX_LARGE	
      );
COMMIT;
EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
END;
/
