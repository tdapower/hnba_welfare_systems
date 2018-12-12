CREATE OR REPLACE PROCEDURE INSERT_WS_SURVEY_2015_MAIN(
  COMPANY		 VARCHAR2,
  EPF_NO             NUMBER,
  NAME         		 VARCHAR2,
  BRANCH_CODE        VARCHAR2,
  RES_ADDRESS_1      VARCHAR2,
  RES_ADDRESS_2      VARCHAR2,
  RES_ADDRESS_3      VARCHAR2,
  SEX	      		 VARCHAR2,
  MARITIAL_STATUS 	 VARCHAR2,
  NAME_OF_SPOUSE     VARCHAR2,
  NO_OF_CHILDREN  	 NUMBER,
  CH1_NAME       VARCHAR2,
  CH1_DOB        DATE,
  CH1_SEX      VARCHAR2,
  CH2_NAME       VARCHAR2,
  CH2_DOB        DATE,
  CH2_SEX      VARCHAR2,
  CH3_NAME       VARCHAR2,
  CH3_DOB        DATE,
  CH3_SEX      VARCHAR2,
  CH4_NAME       VARCHAR2,
  CH4_DOB        DATE,
  CH4_SEX      VARCHAR2,
  CH5_NAME       VARCHAR2,
  CH5_DOB        DATE,
  CH5_SEX      VARCHAR2
)
IS 


BEGIN
     
      INSERT INTO  WS_SURVEY_2015_MAIN
      (
				COMPANY		 ,
			  EPF_NO             ,
			  NAME         		 ,
			  BRANCH_CODE        ,
			  RES_ADDRESS_1      ,
			  RES_ADDRESS_2      ,
			  RES_ADDRESS_3      ,
			  SEX	      		 ,
			  MARITIAL_STATUS 	 ,
			  NAME_OF_SPOUSE     ,
			  NO_OF_CHILDREN  	 ,
			  CH1_NAME       ,
			  CH1_DOB        ,
			  CH1_SEX      ,
			  CH2_NAME       ,
			  CH2_DOB        ,
			  CH2_SEX      ,
			  CH3_NAME       ,
			  CH3_DOB        ,
			  CH3_SEX      ,
			  CH4_NAME       ,
			  CH4_DOB        ,
			  CH4_SEX      ,
			  CH5_NAME       ,
			  CH5_DOB        ,
			  CH5_SEX  
      )
      VALUES
      (
		   V_COMPANY		 ,
			  V_EPF_NO             ,
			  V_NAME         		 ,
			  V_BRANCH_CODE        ,
			  V_RES_ADDRESS_1      ,
			  V_RES_ADDRESS_2      ,
			  V_RES_ADDRESS_3      ,
			  V_SEX	      		 ,
			  V_MARITIAL_STATUS 	 ,
			  V_NAME_OF_SPOUSE     ,
			  V_NO_OF_CHILDREN  	 ,
			  V_CH1_NAME       ,
			  V_CH1_DOB        ,
			  V_CH1_SEX      ,
			  V_CH2_NAME       ,
			  V_CH2_DOB        ,
			  V_CH2_SEX      ,
			  V_CH3_NAME       ,
			  V_CH3_DOB        ,
			  V_CH3_SEX      ,
			  V_CH4_NAME       ,
			  V_CH4_DOB        ,
			  V_CH4_SEX      ,
			  V_CH5_NAME       ,
			  V_CH5_DOB        ,
			  V_CH5_SEX     
		  SYSDATE       
      );
COMMIT;
EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
END;
/



