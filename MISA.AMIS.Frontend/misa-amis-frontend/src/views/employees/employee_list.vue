<template>
    <div style="height: 100%; position: relative">
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
                        <input v-on:change="search()" v-model="filter" class="ms-input" type="text" placeholder="Tìm theo mã, tên nhân viên">
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
                <pagination :totalPages="totalPage"
                :totalRecord="totalRecord"
                :pageSize="pageSize"
                :page="page" 
                @onChangePage="onChangePage"
                @onChangePageSize="onChangePageSize"/>
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
import Pagination from '../../components/pagination.vue';

export default {
    name: "EmployeeList",
    components: {
        MyDropBox,
        EmployeeDialog,
        ConfirmDialog,
        Pagination
    },
    data: function(){
        return {
            employees: [],
            page: 1,
            pageSize: 20,
            totalRecord: 0,
            filter: "",
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
            return date === null? "Không xác định" : date.substring(0,10).split("-").reverse().join("/");
        },
        showDialog: function(employeeId){
            console.log(employeeId);
            this.$refs.form.show(employeeId);
        },
        refresh: function(){
            axios.get("https://localhost:5001/api/v1/employees/paging?pageIndex="+this.page+"&pageSize="+this.pageSize+"&filter="+this.filter)
                .then((response) => {
                    this.employees = response.data.data;
                    this.totalRecord = response.data.totalRecords;
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
        },
        onChangePage(page) {
            if(page > 0){
                this.page = page;
                this.refresh();
            }
        },
        onChangePageSize(pageSize) {
            this.pageSize = pageSize;
            this.refresh();
        },
        search: function(){
            this.page = 1;
            this.refresh();
        }
    },

    mounted: function(){
        axios.get("https://localhost:5001/api/v1/employees/paging?pageIndex="+this.page+"&pageSize="+this.pageSize+"&filter="+this.filter)
        .then((response) => {
            this.employees = response.data.data;
            this.totalRecord = response.data.totalRecords;
            console.log(response);
        })
        .catch((response) => {
            console.log(response);
        });
    },
    computed:{
        totalPage: function(){
            return Math.ceil(this.totalRecord / this.pageSize);
        }
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
    height: calc(100% - 56px);
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
    height: calc(100% - 120px);
    overflow-y: auto;
    margin-top: 10px;
}



</style>