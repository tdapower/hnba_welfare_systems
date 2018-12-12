CREATE OR REPLACE PROCEDURE INSERT_WS_SURVEY_CHILD(
  V_EMP_EPF           	 NUMBER,
  V_NAME         		 VARCHAR2,
  V_SEX	      		 VARCHAR2,
  V_DOB        DATE
)
IS 
        V_ID WS_SURVEY_CHILD.ID%TYPE;

BEGIN
      SELECT CASE WHEN MAX(ID)  IS NULL THEN 1 ELSE TO_NUMBER((MAX(ID)+1)) END INTO V_ID FROM WS_SURVEY_CHILD;
     
      INSERT INTO  WS_SURVEY_CHILD
      (
		  ID      ,
		  EMP_EPF   ,
		  NAME    ,
		  DOB   ,
		  SEX      
      )
      VALUES
      (
		  V_ID      ,
		  V_EMP_EPF   ,
		  V_NAME    ,
		  V_DOB   ,
		  V_SEX           
      );
COMMIT;
EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
END;
/

