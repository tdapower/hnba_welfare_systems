-- Create table
create table WS_SURVEY_2016_MAIN
(
  COMPANY		 VARCHAR2(20),
  EPF_NO             NUMBER(6),
  NAME         		 VARCHAR2(250),
  BRANCH_CODE        VARCHAR2(20),
  RES_ADDRESS_1      VARCHAR2(250),
  RES_ADDRESS_2      VARCHAR2(250),
  RES_ADDRESS_3      VARCHAR2(250),
  SEX	      		 VARCHAR2(1),
  MARITIAL_STATUS 	 VARCHAR2(1),
  NAME_OF_SPOUSE     VARCHAR2(250),
  NO_OF_CHILDREN  	 NUMBER(2),
  CH1_NAME       VARCHAR2(250),
  CH1_DOB        DATE,
  CH1_SEX      VARCHAR2(1),
  CH2_NAME       VARCHAR2(250),
  CH2_DOB        DATE,
  CH2_SEX      VARCHAR2(1),
  CH3_NAME       VARCHAR2(250),
  CH3_DOB        DATE,
  CH3_SEX      VARCHAR2(1),
  CH4_NAME       VARCHAR2(250),
  CH4_DOB        DATE,
  CH4_SEX      VARCHAR2(1),
  CH5_NAME       VARCHAR2(250),
  CH5_DOB        DATE,
  CH5_SEX      VARCHAR2(1),
  SYSTEM_DATE        DATE,
  Primary key (COMPANY,EPF_NO)
)
tablespace TBS_HNBA_DAT
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );