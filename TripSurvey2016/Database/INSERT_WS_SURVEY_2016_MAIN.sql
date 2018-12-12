CREATE OR REPLACE PROCEDURE INSERT_WS_SURVEY_2016_MAIN(
  V_COMPANY		 VARCHAR2,
  V_EPF_NO             NUMBER,
  V_NAME         		 VARCHAR2,
  V_BRANCH_CODE        VARCHAR2,
  V_RES_ADDRESS_1      VARCHAR2,
  V_RES_ADDRESS_2      VARCHAR2,
  V_RES_ADDRESS_3      VARCHAR2,
  V_SEX	      		 VARCHAR2,
  V_MARITIAL_STATUS 	 VARCHAR2,
  V_NAME_OF_SPOUSE     VARCHAR2,
  V_NO_OF_CHILDREN  	 NUMBER,
 V_CH1_NAME       VARCHAR2,
  V_CH1_DOB        DATE,
  V_CH1_SEX      VARCHAR2,
   V_CH2_NAME       VARCHAR2,
  V_CH2_DOB        DATE,
  V_CH2_SEX      VARCHAR2,  
  V_CH3_NAME       VARCHAR2,
  V_CH3_DOB        DATE,
  V_CH3_SEX      VARCHAR2,
  V_CH4_NAME       VARCHAR2,
  V_CH4_DOB        DATE,
  V_CH4_SEX      VARCHAR2,
  V_CH5_NAME       VARCHAR2,
  V_CH5_DOB        DATE,
  V_CH5_SEX      VARCHAR2 
)
IS 

 
 


BEGIN
     
     INSERT INTO  WS_SURVEY_2016_MAIN
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
			  CH5_SEX  ,
			  SYSTEM_DATE
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
			  V_CH5_SEX     ,
		  SYSDATE       
      ); 
COMMIT;
EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
END;
/



