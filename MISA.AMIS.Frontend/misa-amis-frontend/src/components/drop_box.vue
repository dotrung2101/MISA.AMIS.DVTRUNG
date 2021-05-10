<template>
    <div class="drop-box-container">
        <div class="btn-container">
            <div class="btn-edit" v-on:click="editClick()">Sửa</div>
            <button class="btn-drop" v-on:click="dropDown()">
                <div class="mi mi-16 mi-arrow-up-blue" ></div>
            </button>
        </div>
        <div class="drop-down" v-bind:class="{show: isShow}">
            <ul>
                <li>Nhân bản</li>
                <li v-on:click="handleDelete(employeeId)">Xóa</li>
                <li>Ngừng sử dụng</li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
    name:"MyDropBox",
    data: function(){
        return {
            isShow: false,
        }
    },
    props:['employeeId'],
    methods: {
        dropDown: function(){
            this.isShow = !this.isShow;
        },
        removeDropDown: function(){
            this.isShow = false;
        },
        editClick: function(){
            this.$parent.showDialog(this.employeeId);
        },
        handleDelete: function(employeeId){
            this.$parent.showConfirmDialog(employeeId);
        }
    }
}
</script>

<style scoped>
@font-face {
    font-family: "notosans-regular";
    src: url("../assets/fonts/notosans-regular.2cb88a13.woff2") format("opentype");
}

@font-face {
    font-family: "notosans-italic";
    src: url("../assets/fonts/notosans-italic.1c1aaac9.woff2") format("opentype");
}
  
@font-face {
    font-family: "notosans-bold";
    src: url("../assets/fonts/notosans-bold.3ede5aff.woff2") format("opentype");
}
  
@font-face {
    font-family: "notosans-semibold";
    src: url("../assets/fonts/notosans-semibold.df3e6dc4.woff2") format("opentype");
}
.drop-box-container{
    width: 100%;
    height: 100%;
    position: relative;
    background: white;
}

.btn-container{
    display: flex;
    align-items: center;
    width: 100%;
}

.btn-edit{
    font-size: 12px;
    font-family: notosans-bold;
    color: #0075c0;
    padding: 6px 2px 6px 16px;
}

.btn-drop:focus{
    border: 1px solid #0075c0;
}

.btn-drop{
    padding: 6px 10px;
    border: none;
    background: none;
}
.drop-down{
  width: 120px;
  background: white;
  position: absolute;
  top: 100%;
  left: 0;
  border: 1px solid #707070;
  overflow: hidden;
  z-index: 1000;
  display: none;
}

.drop-down.show{
    display: block;
}

.drop-down ul{
  list-style: none;
  padding: 0;
  margin: 0;
}

.drop-down ul li{
  width: 100%;
  padding: 5px 10px;
  font-size: 13px;
  font-family: notosans-regular;
  cursor: pointer;
}

.drop-down ul li:hover{
  background: #eeeeee;
}
</style>