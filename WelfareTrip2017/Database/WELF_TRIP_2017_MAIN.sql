-- Create table
create table WELF_TRIP_2017_MAIN
(
  SEQ_ID 	 NUMBER(5),
  COMPANY		 VARCHAR2(20),
  BRANCH_DEPT		 VARCHAR2(100), 
  EPF_NO             NUMBER(6),
  MEMBER_NAME        VARCHAR2(250),
  MEMBER_GENDER        VARCHAR2(10),
  MARITIAL_STATUS 	 VARCHAR2(1),
  SPOUSE_NAME     VARCHAR2(250),
  CH1_NAME       VARCHAR2(250),
  CH1_DOB        DATE,
  CH2_NAME       VARCHAR2(250),
  CH2_DOB        DATE,
  CH3_NAME       VARCHAR2(250),
  CH3_DOB        DATE,
  CH4_NAME       VARCHAR2(250),
  CH4_DOB        DATE,
  CH5_NAME       VARCHAR2(250),
  CH5_DOB        DATE,
  IS_MEMBER_PARTICIPATE   NUMBER(1),
  IS_SPOUSE_PARTICIPATE   NUMBER(1),  
  IS_CH1_PARTICIPATE   NUMBER(1),  
  IS_CH2_PARTICIPATE   NUMBER(1),  
  IS_CH3_PARTICIPATE   NUMBER(1),
  IS_CH4_PARTICIPATE   NUMBER(1),
  IS_CH5_PARTICIPATE   NUMBER(1),  
  PARTICIPATE_DATE		 VARCHAR2(50),  
  MEMBER_COST   NUMBER(10,2),  
  ROOM_SEQ_ID		 VARCHAR2(20),
  REMARKS		 VARCHAR2(300),
  SYSTEM_DATE        DATE,
  Primary key (SEQ_ID)
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