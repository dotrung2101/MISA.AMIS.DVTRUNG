<template>
    <div class="dialog" v-bind:class="{show: isShow}">
        <div class="dialog-model">

        </div>
        <div class="dialog-content">
            <div class="header-form">Thông tin nhân viên</div>
            <div class="popup-tool">
                <div class="mi mi-24 mi-help" style="margin-right: 6px"></div>
                <div class="mi mi-24 mi-close" v-on:click="close()"></div>
            </div>
            <div class="dialog-form">
                <div class="horizontal">
                    <div class="form-element">
                        <label for="txt-employee-code">Mã <span>*</span></label>
                        <input v-bind:class="{validate: isValidateEmployeeCode}" v-on:input="validateEmployeeCode()" v-model="employee.employeeCode" type="text" id="txt-employee-code" style="width: 150px; margin-right: 6px">
                        <div class="validate-message">Mã nhân viên không được phép để trống</div>
                    </div>
                    <div class="form-element">
                        <label for="txt-employee-name">Tên <span>*</span></label>
                        <input v-bind:class="{validate: isValidateFullName}" v-on:input="validateFullName()" v-model="employee.fullName" type="text" id="txt-employee-name" style="width: 240px; margin-right: 26px">
                        <div class="validate-message">Tên nhân viên không được phép để trống</div>
                    </div>
                    <div class="form-element">
                        <label for="txt-employee-date-of-birth">Ngày sinh</label>
                        <input v-model="employee.dateOfBirth" type="date" id="txt-employee-date-of-birth" style="width: 160px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label >Giới tính</label>
                        <div class="container-radio">
                            <input v-model="employee.gender" type="radio" id="male" name="gender" value="1">
                            <label for="male">Nam</label><br>
                            <input v-model="employee.gender" type="radio" id="female" name="gender" value="0">
                            <label for="female">Nữ</label><br>
                            <input v-model="employee.gender" type="radio" id="other" name="gender" value="2">
                            <label for="other">Khác</label>
                        </div>
                    </div>
                </div>
                <div class="horizontal">
                    <div class="form-element">
                        <label for="cb-department">Đơn vị <span>*</span></label>
                        <select v-bind:class="{validate: isValidateDepartment}" v-on:input="validateDepartment()" v-model="employee.departmentId" name="department" id="cb-department" style="width: 440px; margin-right: 26px">
                            <option v-for="department in departments" v-bind:value="department.departmentId" :key="department.departmentId">{{department.departmentName}}</option>
                        </select>
                        <div class="validate-message">Đơn vị không được phép để trống</div>
                    </div>
                    <div class="form-element">
                        <label>Số CMND</label>
                        <input v-bind:class="{validate: isValidateIdentifyNumber}" v-on:input="validateIdentifyNumber()" v-model="employee.identifyNumber" type="text" id="txt-employee-IN" style="width: 200px; margin-right: 12px">
                        <div class="validate-message">{{identifyNumberValidateMessage}}</div>
                    </div>
                    <div class="form-element">
                        <label>Ngày cấp</label>
                        <input v-model="employee.dateOfIN" type="date" id="txt-employee-date-of-IN" style="width: 160px; margin-right: 12px">
                    </div>
                </div>

                <div class="horizontal">
                    <div class="form-element">
                        <label>Chức danh</label>
                        <input v-model="employee.positionName" type="text" style="width: 420px; margin-right: 26px">
                    </div>
                    <div class="form-element">
                        <label>Nơi cấp</label>
                        <input v-model="employee.placeOfIN" type="text" style="width: 395px">
                    </div>
                </div>
                <div style="height: 20px"></div>
                <div class="horizontal">
                    <div class="form-element">
                        <label>Địa chỉ</label>
                        <input v-model="employee.address" type="text" style="width: 865px">
                    </div>
                </div>
                <div class="horizontal">
                    <div class="form-element">
                        <label>ĐT di động</label>
                        <input v-bind:class="{validate: isValidatePhoneNumber}" v-on:input="validatePhoneNumber()" v-model="employee.phoneNumber" type="text" style="width: 250px; margin-right: 12px">
                        <div class="validate-message">{{phoneNumberValidateMessage}}</div>
                    </div>
                    <div class="form-element">
                        <label>ĐT cố định</label>
                        <input v-model="employee.phoneStatic" type="text" style="width: 250px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>Email</label>
                        <input v-bind:class="{validate: isValidateEmail}" v-on:input="validateEmail()" v-model="employee.email" type="text" style="width: 250px; margin-right: 12px">
                        <div class="validate-message">{{emailValidateMessage}}</div>
                    </div>
                </div>
                <div class="horizontal">
                    <div class="form-element">
                        <label>Tài khoản ngân hàng</label>
                        <input v-model="employee.bankAccount" type="text" style="width: 250px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>Tên ngân hàng</label>
                        <input v-model="employee.bankName" type="text" style="width: 250px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>Chi nhánh</label>
                        <input v-model="employee.bankBranch" type="text" style="width: 250px; margin-right: 12px">
                    </div>
                </div>
                <div class="line"></div>
                <div style="height: 20px"></div>
                <div class="horizontal">
                    <button class="second-button">Hủy</button>
                    <div style="flex: 1"></div>
                    <button class="second-button">Cất</button>
                    <div style="width: 12px"></div>
                    <button v-on:click="submit()" class="btn-primary">Cất và Thêm</button>
                </div>
            </div>
            <div class="dialog-content-model" v-bind:class="{show: isLoading}">
                <div class="mi mi-24 mi-refresh-blue rotate"></div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    name: "EmployeeDialog",
    data: function(){
        return {
            isShow: false,
            employee: {
                "employeeCode": "",
                "fullName": "",
                "dateOfBirth": "",
                "gender": 1,
                "identifyNumber": "",
                "dateOfIN": "",
                "placeOfIN": "",
                "email": "",
                "phoneNumber": "",
                "positionName": "",
                "departmentId": "",
                "taxCode": "",
                "address": "",
                "phoneStatic": "",
                "bankAccount": "",
                "bankName": "",
                "bankBranch": "",
            },
            departments: [],
            isLoading: false,
            formMode: 0,
            isValidateEmployeeCode: false,
            isValidateFullName: false,
            isValidateIdentifyNumber: false,
            isValidatePhoneNumber: false,
            isValidateEmail: false,
            isValidateDepartment: false,
            emailValidateMessage: "Email không được phép để trống",
            phoneNumberValidateMessage: "Số điện thoại không được phép để trống",
            identifyNumberValidateMessage: "Số CMND/CC không được phép để trống"
        }
    },
    methods: {
        show: function(employeeId){
            this.isShow = true;
            this.isValidateEmployeeCode = false;
            this.isValidateFullName = false;
            this.isValidateIdentifyNumber = false;
            this.isValidatePhoneNumber = false;
            this.isValidateEmail = false;
            this.isValidateDepartment = false;
            if(employeeId != null){
                this.isLoading = true;
                this.formMode = 1;
                axios.get("https://localhost:5001/api/v1/employees/"+employeeId)
                .then((response) => {
                    this.employee = response.data;
                    console.log(this.employee);
                    this.employee.dateOfBirth = this.employee.dateOfBirth.substring(0,10);
                    this.employee.dateOfIN = this.employee.dateOfIN.substring(0,10);
                    this.isLoading = false;
                })
                .catch((response) => {
                    console.log(response);
                    this.isLoading = false;
                });
            }
            else{
                this.formMode = 0;
                this.employee = {
                    "employeeCode": "",
                    "fullName": "",
                    "dateOfBirth": "",
                    "gender": 1,
                    "identifyNumber": "",
                    "dateOfIN": "",
                    "placeOfIN": "",
                    "email": "",
                    "phoneNumber": "",
                    "positionName": "",
                    "departmentId": "",
                    "taxCode": "",
                    "address": "",
                    "phoneStatic": "",
                    "bankAccount": "",
                    "bankName": "",
                    "bankBranch": "",
                };
            }
        },
        close: function(){
            this.isShow = false;
        },
        submit: function(){
            if(this.formMode == 1){
                //edit
                axios.put("https://localhost:5001/api/v1/employees/"+this.employee.employeeId, this.employee)
                .then((response) => {
                    console.log(response);
                    this.close();
                    this.$parent.refresh();
                })
                .catch((response) => {
                    console.log(response);
                })
            }
            else{
                //insert
                console.log("INSERT");
                console.log(JSON.stringify(this.employee));
                axios.post("https://localhost:5001/api/v1/employees",this.employee)
                .then((response) => {
                    console.log(response);
                    this.close();
                    this.$parent.refresh();
                })
                .catch((response) => {
                    console.log(response);
                })
            }
        },
        validateEmployeeCode: function(){
            if(this.employee.employeeCode === ""){
                this.isValidateEmployeeCode = true;
            }
            else{
                this.isValidateEmployeeCode = false;
            }
        },
        validateFullName: function(){
            if(this.employee.fullName === ""){
                this.isValidateFullName = true;
            }
            else{
                this.isValidateFullName = false;
            }
        },
        validateDepartment: function(){
            if(this.employee.departmentId === ""){
                this.isValidateDepartment = true;
            }
            else{
                this.isValidateDepartment = false;
            }
        },
        validateIdentifyNumber: function(){
            if(this.employee.identifyNumber === ""){
                this.isValidateIdentifyNumber = true;
            }
            else if(isNaN(this.employee.identifyNumber)){
                this.identifyNumberValidateMessage = "Số CMND/CC không hợp lệ"
                this.isValidateIdentifyNumber = true;
            }
            else{
                this.isValidateIdentifyNumber = false;
            }
        },
        validatePhoneNumber: function(){
            if(this.employee.phoneNumber === ""){
                this.isValidatePhoneNumber = true;
            }
            else if(isNaN(this.employee.phoneNumber)){
                this.isValidatePhoneNumber = true;
                this.phoneNumberValidateMessage = "Số điện thoại không hợp lệ"
            }
            else{
                this.isValidatePhoneNumber = false;
            }
        },
        validateEmail: function(){
            const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            if(this.employee.email === ""){
                this.isValidateEmail = true;
            }
            else if(!re.test(this.employee.email.toLowerCase())){
                this.isValidateEmail = true;
                this.emailValidateMessage = "Email không hợp lệ";
            }
            else{
                this.isValidateEmail = false;
            }
        },
    },
    beforeCreate: function(){
        axios.get("https://localhost:5001/api/v1/departments")
        .then((response) => {
            this.departments = response.data;
        })
        .catch((response) => {
            console.log(response);
        })
    },
}
</script>

<style scoped>
@font-face {
    font-family: "notosans-regular";
    src: url("../../assets/fonts/notosans-regular.2cb88a13.woff2") format("opentype");
}

@font-face {
    font-family: "notosans-italic";
    src: url("../../assets/fonts/notosans-italic.1c1aaac9.woff2") format("opentype");
}
  
@font-face {
    font-family: "notosans-bold";
    src: url("../../assets/fonts/notosans-bold.3ede5aff.woff2") format("opentype");
}
  
@font-face {
    font-family: "notosans-semibold";
    src: url("../../assets/fonts/notosans-semibold.df3e6dc4.woff2") format("opentype");
}
.dialog{
    display: none;
}
.dialog.show{
    display: block;
}
.dialog-model{
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100vh;
    background: rgba(0, 0, 0, 0.4);
    z-index: 1000;
}
.dialog-content{
    position: fixed;
    top: 50%;
    left: 50%;
    width: 940px;
    height: 600px;
    background: #fff;
    transform: translateX(-50%) translateY(-50%);
    display: flex;
    flex-direction: column;
    z-index: 1000;
}
.header-form{
    padding: 20px 12px 20px 32px;
    font-size: 24px;
    font-family: notosans-bold;
    text-align: left;
}

.popup-tool{
    position: absolute;
    top: 0;
    right: 0;
    display: flex;
    padding: 12px;
}

.dialog-form{
    flex: 1;
    padding: 0px 32px 20px;
}
.horizontal{
    display: flex;
    margin-bottom: 12px;
}

.form-element{
    display: flex;
    flex-direction: column;
    position: relative;
}
label{
    font-size: 12px;
    font-family: notosans-bold;
    color: black;
    display: block;
    text-align: left;
    padding: 0px 0px 4px;
}
label span{
    color: red;
}
.container-radio{
    display: flex;
    align-items: center;
}
.container-radio label{
    font-family: notosans-regular;
    margin-top: 5px;
}
.line{
    width: 100%;
    height: 1px;
    background: #cccccc;
    margin-top: 40px;
}
.dialog-content-model{
    width: 940px;
    height: 600px;
    background: rgba(0, 0, 0, 0.1);
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translateX(-50%) translateY(-50%);
    display: none;
}
.dialog-content-model.show{
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 1000;
}

</style>