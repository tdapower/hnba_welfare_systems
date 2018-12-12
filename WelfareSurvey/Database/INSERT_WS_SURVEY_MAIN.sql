CREATE OR REPLACE PROCEDURE INSERT_WS_SURVEY_MAIN(
  V_NAME         		 VARCHAR2,
  V_EPF_NO             NUMBER,
  V_BRANCH_CODE        VARCHAR2,
  V_RES_ADDRESS_1      VARCHAR2,
  V_RES_ADDRESS_2      VARCHAR2,
  V_RES_ADDRESS_3      VARCHAR2,
  V_SEX	      		 VARCHAR2,
  V_MARITIAL_STATUS 	 VARCHAR2,
  V_NAME_OF_SPOUSE     VARCHAR2,
  V_NO_OF_CHILDREN  	 NUMBER,
  V_COMPANY   VARCHAR2,
  V_NEW_ID OUT NUMBER
)
IS 
        V_ID WS_SURVEY_MAIN.ID%TYPE;

BEGIN
      SELECT CASE WHEN MAX(ID)  IS NULL THEN 1 ELSE TO_NUMBER((MAX(ID)+1)) END INTO V_ID FROM WS_SURVEY_MAIN;
      V_NEW_ID:=V_ID;
	  
      INSERT INTO  WS_SURVEY_MAIN
      (
		  ID        		 ,
		  NAME         		,
		  EPF_NO           ,
		  BRANCH_CODE       ,
		  RES_ADDRESS_1     ,
		  RES_ADDRESS_2    ,
		  RES_ADDRESS_3     ,
		  SEX	      		,
		  MARITIAL_STATUS 	,
		  NAME_OF_SPOUSE   ,
		  NO_OF_CHILDREN  	,
		  SYSTEM_DATE        ,
		  COMPANY
      )
      VALUES
      (
		  V_ID        		 ,
		  V_NAME         		,
		  V_EPF_NO           ,
		  V_BRANCH_CODE       ,
		  V_RES_ADDRESS_1     ,
		  V_RES_ADDRESS_2    ,
		  V_RES_ADDRESS_3     ,
		  V_SEX	      		,
		  V_MARITIAL_STATUS 	,
		  V_NAME_OF_SPOUSE   ,
		  V_NO_OF_CHILDREN  	,
		  SYSDATE        ,
		  V_COMPANY
      );
COMMIT;
EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
END;
/