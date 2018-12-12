CREATE OR REPLACE PROCEDURE INSERT_WELF_PARTY_CONF(
  V_EPF_NO             NUMBER
)
IS 

BEGIN
     
	  
      INSERT INTO  WELF_PARTY_CONF
      (
		  EPF_NO           ,
		  SYSTEM_DATE        
      )
      VALUES
      (
		  V_EPF_NO           ,
		  SYSDATE        
      );
COMMIT;
EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
END;
/