package com.itg.pms.info.entity;

import java.math.BigDecimal;
import java.util.Date;
import javax.persistence.*;

@Table(name = "s_pms_project_info")
public class SPmsProjectInfo {
    /**
     * 主键id
     */
    @Id
    private String id;

    /**
     * 任务单号
     */
    private String code;

    /**
     * 项目名称
     */
    private String name;

    /**
     * uuid
     */
    private String uni_code;

    /**
     * 项目类型
     */
    private String category;

    /**
     * 主管部门编号
     */
    private String orgcode;

    /**
     * 主管部门名称
     */
    private String orgname;

    /**
     * 委托单位
     */
    private String entrust_unit;

    /**
     * 项目负责人编号
     */
    private String usercode;

    /**
     * 项目负责人名称
     */
    private String username;

    /**
     * 副项目负责人
     */
    private String subuser;

    /**
     * 项目级别
     */
    private String level;

    /**
     * 项目所在地
     */
    private String location;

    /**
     * 线路
     */
    private String line;

    /**
     * 重要性
     */
    private String importance;

    /**
     * 紧急程度
     */
    private String urgency;

    /**
     * 项目范围
     */
    private String scope;

    /**
     * 项目状态：-1已删除、0草稿、1待审批、3审批中、5策划进行中、7项目进行中、9已终止、11已完成
     */
    private Short status;

    /**
     * 版本号
     */
    private Float version;

    /**
     * 项目产值
     */
    private BigDecimal output_value;

    /**
     * 项目依据
     */
    private String file;

    /**
     * 创建人编号
     */
    private String create_usercode;

    /**
     * 创建人名称
     */
    private String create_username;

    /**
     * 创建时间
     */
    private Date create_time;

    /**
     * 获取主键id
     *
     * @return id - 主键id
     */
    public String getId() {
        return id;
    }

    /**
     * 设置主键id
     *
     * @param id 主键id
     */
    public void setId(String id) {
        this.id = id == null ? null : id.trim();
    }

    /**
     * 获取任务单号
     *
     * @return code - 任务单号
     */
    public String getCode() {
        return code;
    }

    /**
     * 设置任务单号
     *
     * @param code 任务单号
     */
    public void setCode(String code) {
        this.code = code == null ? null : code.trim();
    }

    /**
     * 获取项目名称
     *
     * @return name - 项目名称
     */
    public String getName() {
        return name;
    }

    /**
     * 设置项目名称
     *
     * @param name 项目名称
     */
    public void setName(String name) {
        this.name = name == null ? null : name.trim();
    }

    /**
     * 获取uuid
     *
     * @return uni_code - uuid
     */
    public String getUni_code() {
        return uni_code;
    }

    /**
     * 设置uuid
     *
     * @param uni_code uuid
     */
    public void setUni_code(String uni_code) {
        this.uni_code = uni_code == null ? null : uni_code.trim();
    }

    /**
     * 获取项目类型
     *
     * @return category - 项目类型
     */
    public String getCategory() {
        return category;
    }

    /**
     * 设置项目类型
     *
     * @param category 项目类型
     */
    public void setCategory(String category) {
        this.category = category == null ? null : category.trim();
    }

    /**
     * 获取主管部门编号
     *
     * @return orgcode - 主管部门编号
     */
    public String getOrgcode() {
        return orgcode;
    }

    /**
     * 设置主管部门编号
     *
     * @param orgcode 主管部门编号
     */
    public void setOrgcode(String orgcode) {
        this.orgcode = orgcode == null ? null : orgcode.trim();
    }

    /**
     * 获取主管部门名称
     *
     * @return orgname - 主管部门名称
     */
    public String getOrgname() {
        return orgname;
    }

    /**
     * 设置主管部门名称
     *
     * @param orgname 主管部门名称
     */
    public void setOrgname(String orgname) {
        this.orgname = orgname == null ? null : orgname.trim();
    }

    /**
     * 获取委托单位
     *
     * @return entrust_unit - 委托单位
     */
    public String getEntrust_unit() {
        return entrust_unit;
    }

    /**
     * 设置委托单位
     *
     * @param entrust_unit 委托单位
     */
    public void setEntrust_unit(String entrust_unit) {
        this.entrust_unit = entrust_unit == null ? null : entrust_unit.trim();
    }

    /**
     * 获取项目负责人编号
     *
     * @return usercode - 项目负责人编号
     */
    public String getUsercode() {
        return usercode;
    }

    /**
     * 设置项目负责人编号
     *
     * @param usercode 项目负责人编号
     */
    public void setUsercode(String usercode) {
        this.usercode = usercode == null ? null : usercode.trim();
    }

    /**
     * 获取项目负责人名称
     *
     * @return username - 项目负责人名称
     */
    public String getUsername() {
        return username;
    }

    /**
     * 设置项目负责人名称
     *
     * @param username 项目负责人名称
     */
    public void setUsername(String username) {
        this.username = username == null ? null : username.trim();
    }

    /**
     * 获取副项目负责人
     *
     * @return subuser - 副项目负责人
     */
    public String getSubuser() {
        return subuser;
    }

    /**
     * 设置副项目负责人
     *
     * @param subuser 副项目负责人
     */
    public void setSubuser(String subuser) {
        this.subuser = subuser == null ? null : subuser.trim();
    }

    /**
     * 获取项目级别
     *
     * @return level - 项目级别
     */
    public String getLevel() {
        return level;
    }

    /**
     * 设置项目级别
     *
     * @param level 项目级别
     */
    public void setLevel(String level) {
        this.level = level == null ? null : level.trim();
    }

    /**
     * 获取项目所在地
     *
     * @return location - 项目所在地
     */
    public String getLocation() {
        return location;
    }

    /**
     * 设置项目所在地
     *
     * @param location 项目所在地
     */
    public void setLocation(String location) {
        this.location = location == null ? null : location.trim();
    }

    /**
     * 获取线路
     *
     * @return line - 线路
     */
    public String getLine() {
        return line;
    }

    /**
     * 设置线路
     *
     * @param line 线路
     */
    public void setLine(String line) {
        this.line = line == null ? null : line.trim();
    }

    /**
     * 获取重要性
     *
     * @return importance - 重要性
     */
    public String getImportance() {
        return importance;
    }

    /**
     * 设置重要性
     *
     * @param importance 重要性
     */
    public void setImportance(String importance) {
        this.importance = importance == null ? null : importance.trim();
    }

    /**
     * 获取紧急程度
     *
     * @return urgency - 紧急程度
     */
    public String getUrgency() {
        return urgency;
    }

    /**
     * 设置紧急程度
     *
     * @param urgency 紧急程度
     */
    public void setUrgency(String urgency) {
        this.urgency = urgency == null ? null : urgency.trim();
    }

    /**
     * 获取项目范围
     *
     * @return scope - 项目范围
     */
    public String getScope() {
        return scope;
    }

    /**
     * 设置项目范围
     *
     * @param scope 项目范围
     */
    public void setScope(String scope) {
        this.scope = scope == null ? null : scope.trim();
    }

    /**
     * 获取项目状态：-1已删除、0草稿、1待审批、3审批中、5策划进行中、7项目进行中、9已终止、11已完成
     *
     * @return status - 项目状态：-1已删除、0草稿、1待审批、3审批中、5策划进行中、7项目进行中、9已终止、11已完成
     */
    public Short getStatus() {
        return status;
    }

    /**
     * 设置项目状态：-1已删除、0草稿、1待审批、3审批中、5策划进行中、7项目进行中、9已终止、11已完成
     *
     * @param status 项目状态：-1已删除、0草稿、1待审批、3审批中、5策划进行中、7项目进行中、9已终止、11已完成
     */
    public void setStatus(Short status) {
        this.status = status;
    }

    /**
     * 获取版本号
     *
     * @return version - 版本号
     */
    public Float getVersion() {
        return version;
    }

    /**
     * 设置版本号
     *
     * @param version 版本号
     */
    public void setVersion(Float version) {
        this.version = version;
    }

    /**
     * 获取项目产值
     *
     * @return output_value - 项目产值
     */
    public BigDecimal getOutput_value() {
        return output_value;
    }

    /**
     * 设置项目产值
     *
     * @param output_value 项目产值
     */
    public void setOutput_value(BigDecimal output_value) {
        this.output_value = output_value;
    }

    /**
     * 获取项目依据
     *
     * @return file - 项目依据
     */
    public String getFile() {
        return file;
    }

    /**
     * 设置项目依据
     *
     * @param file 项目依据
     */
    public void setFile(String file) {
        this.file = file == null ? null : file.trim();
    }

    /**
     * 获取创建人编号
     *
     * @return create_usercode - 创建人编号
     */
    public String getCreate_usercode() {
        return create_usercode;
    }

    /**
     * 设置创建人编号
     *
     * @param create_usercode 创建人编号
     */
    public void setCreate_usercode(String create_usercode) {
        this.create_usercode = create_usercode == null ? null : create_usercode.trim();
    }

    /**
     * 获取创建人名称
     *
     * @return create_username - 创建人名称
     */
    public String getCreate_username() {
        return create_username;
    }

    /**
     * 设置创建人名称
     *
     * @param create_username 创建人名称
     */
    public void setCreate_username(String create_username) {
        this.create_username = create_username == null ? null : create_username.trim();
    }

    /**
     * 获取创建时间
     *
     * @return create_time - 创建时间
     */
    public Date getCreate_time() {
        return create_time;
    }

    /**
     * 设置创建时间
     *
     * @param create_time 创建时间
     */
    public void setCreate_time(Date create_time) {
        this.create_time = create_time;
    }
}