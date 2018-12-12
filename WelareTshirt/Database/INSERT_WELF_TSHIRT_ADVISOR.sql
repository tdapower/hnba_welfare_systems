CREATE OR REPLACE PROCEDURE INSERT_WELF_TSHIRT_ADVISOR(
  V_COMPANY            VARCHAR2,
  V_BRANCH_CODE            VARCHAR2,
  V_AGENT_CODE              VARCHAR2,
  V_CONSENT            VARCHAR2,
  V_NO_OF_ITEMS 		 NUMBER,
  V_REMARKS            VARCHAR2,
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
  V_L_DEX_LARGE	NUMBER,
  V_SYSTEM_USER_CODE VARCHAR2
)
IS 
       

BEGIN
     DELETE FROM WELF_TSHIRT_ADVISOR WHERE COMPANY =V_COMPANY AND AGENT_CODE=V_AGENT_CODE;
	  
      INSERT INTO  WELF_TSHIRT_ADVISOR
      (
		  COMPANY            ,
		  BRANCH_CODE            ,
		  AGENT_CODE              ,
		  CONSENT         ,
		  NO_OF_ITEMS 		,
		  REMARKS            ,
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
		  L_DEX_LARGE	,
		  SYSTEM_DATE,
		  SYSTEM_USER_CODE
		  
      )
      VALUES
      (
		  V_COMPANY            ,
		  V_BRANCH_CODE            ,
		  V_AGENT_CODE              , 
		  V_CONSENT           ,
		  V_NO_OF_ITEMS 		 ,
		  V_REMARKS            ,
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
		  V_L_DEX_LARGE	,
		  SYSDATE        ,
		  V_SYSTEM_USER_CODE
		  );
COMMIT;
EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
END;
/






