<template>
    <div>
        <div class="header-di">
                <div class="title-di">
                    Nhân viên
                </div>
                <div style="flex:1"></div>
                <button class="btn-primary" v-on:click="showDialog(null)">Thêm mới nhân viên</button>
            </div>
            <div class="container-table">
                <div class="toolbar-table">
                    <div style="flex:1"></div>
                    <div class="ms-input-container">
                        <input class="ms-input" type="text" placeholder="Tìm theo mã, tên nhân viên">
                        <div class="mi mi-16 mi-search icon-after"></div>
                    </div>
                    <div class="tooltip-content">
                        <div class="mi mi-24 mi-refresh" v-on:click="refresh()"></div>
                    </div>
                    <div class="tooltip-content">
                        <div class="mi mi-24 mi-excel-nav"></div>
                    </div>
                    <div style="width: 10px"></div>
                </div>
                <div class="grid">
                    <table style="width: calc(100% - 30px); margin-left: 10px; margin-right: 0px">
                    <thead>
                        <tr>
                            <th><input type="checkbox"></th>
                            <th>Mã nhân viên</th>
                            <th>Tên nhân viên</th>
                            <th>Giới tính</th>
                            <th>Ngày sinh</th>
                            <th>Số CMND</th>
                            <th>Ngày cấp</th>
                            <th>Nơi cấp</th>
                            <th>Chức danh</th>
                            <th>Chức năng</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="element in employees" :key="element.employeeId">
                            <td><input type="checkbox"></td>
                            <td>{{element.employeeCode}}</td>
                            <td>{{element.fullName}}</td>
                            <td>{{formatGenderName(element.gender)}}</td>
                            <td>{{formatDate(element.dateOfBirth)}}</td>
                            <td>{{element.identifyNumber}}</td>
                            <td>{{formatDate(element.dateOfIN)}}</td>
                            <td>{{element.placeOfIN}}</td>
                            <td>{{element.positionName}}</td>
                            <td><my-drop-box :employeeId="element.employeeId"/></td>
                        </tr>
                    </tbody>
                </table>
                </div>
            </div>
            <employee-dialog ref="form"/>
            <confirm-dialog ref="confirm"/>
    </div>
</template>

<script>
import axios from 'axios';
import MyDropBox from '../../components/drop_box.vue';
import EmployeeDialog from './employee_dialog.vue';
import ConfirmDialog from './employee_confirm_dialog.vue';

export default {
    name: "EmployeeList",
    components: {
        MyDropBox,
        EmployeeDialog,
        ConfirmDialog
    },
    data: function(){
        return {
            employees: [],
        }
    },

    methods: {
        formatGenderName(Gender){
            if(Gender == 1)
                {
                    return "Nam";
                }
                else if(Gender == 0)
                {
                    return "Nữ";
                }
                else
                {
                    return "Không xác định";
                }
        },

        formatDate(date){
            return date.substring(0,10).split("-").reverse().join("/");
        },
        showDialog: function(employeeId){
            console.log(employeeId);
            this.$refs.form.show(employeeId);
        },
        refresh: function(){
            axios.get("https://localhost:5001/api/v1/employees")
            .then((response) => {
                this.employees = response.data;
                console.log(response);
            })
            .catch((response) => {
                console.log(response);
            });
        },
        showConfirmDialog: function(employeeId){
            this.$refs.confirm.show(employeeId);
        },
        delete: function(employeeId){
            axios.delete("https://localhost:5001/api/v1/employees/"+employeeId)
            .then((response) => {
                console.log(response);
                this.refresh();
            })
        }
    },

    mounted: function(){
        axios.get("https://localhost:5001/api/v1/employees")
        .then((response) => {
            this.employees = response.data;
            console.log(response);
        })
        .catch((response) => {
            console.log(response);
        });
    }
}
</script>

<style scoped>
.header-di{
    width: 100%;
    display: flex;
    margin-top: 20px;
    align-items: center;
}
.header-di .title-di{
    font-size: 24px;
    margin-left: 40px;
    color: black;
    font-weight: bold;
    font-family: notosans-bold;
}

.container-table{
    background: #fff;
    margin: 10px 0px;
    padding-top: 10px;
}

.toolbar-table{
    margin-top: 10px;
    display: flex;
    align-items: center;
}

.tooltip-content{
    padding: 0px 6px;
}

.grid{
    width: 100%;
    height: 500px;
    overflow-y: auto;
    margin-top: 10px;
}



</style>