-- Create table
create table WELF_ADVISOR
(
  COMPANY            VARCHAR2(20),
  BRANCH_CODE            VARCHAR2(50),
  AGENT_CODE              VARCHAR2(50),
  AGENT_NAME                VARCHAR2(200), 
  Primary key (COMPANY,AGENT_CODE)
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
  
  