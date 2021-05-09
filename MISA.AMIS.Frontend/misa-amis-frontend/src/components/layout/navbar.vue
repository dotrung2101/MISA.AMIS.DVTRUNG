<template>
    <div id="navbar">
        <div class="logo-container">
            <div class="mi mi-24 mi-logo-option"></div>
            <div class="logo-img"></div>
        </div>
        <div class="menu-item-list">
            <div class="menu-item" v-bind:class="{active: (selectedItem == 0)}" v-on:click="selectItem(0)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-dashboard"></div>
                </div>
                <div class="menu-item-title">
                        Tổng quan
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 1)}" v-on:click="selectItem(1)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-cash"></div>
                </div>
                <div class="menu-item-title">
                        Tiền mặt
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 2)}" v-on:click="selectItem(2)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-bank"></div>
                </div>
                <div class="menu-item-title">
                        Tiền gửi
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 3)}" v-on:click="selectItem(3)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-pu"></div>
                </div>
                <div class="menu-item-title">
                        Mua hàng
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 4)}" v-on:click="selectItem(4)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-sale"></div>
                </div>
                <div class="menu-item-title">
                        Bán hàng
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 5)}" v-on:click="selectItem(5)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-invoice"></div>
                </div>
                <div class="menu-item-title">
                        Quản lí hoá đơn
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 6)}" v-on:click="selectItem(6)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-stock"></div>
                </div>
                <div class="menu-item-title">
                        Kho
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 7)}" v-on:click="selectItem(7)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-tools"></div>
                </div>
                <div class="menu-item-title">
                        Công cụ dụng cụ
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 8)}" v-on:click="selectItem(8)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-fixed-assets"></div>
                </div>
                <div class="menu-item-title">
                        Tài sản cố định
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 9)}" v-on:click="selectItem(9)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-tax"></div>
                </div>
                <div class="menu-item-title">
                        Thuế
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 10)}" v-on:click="selectItem(10)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-price"></div>
                </div>
                <div class="menu-item-title">
                        Giá thành
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 11)}" v-on:click="selectItem(11)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-general"></div>
                </div>
                <div class="menu-item-title">
                        Tổng hợp
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 12)}" v-on:click="selectItem(12)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-budget"></div>
                </div>
                <div class="menu-item-title">
                        Ngân sách
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 13)}" v-on:click="selectItem(13)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-report"></div>
                </div>
                <div class="menu-item-title">
                        Báo cáo
                </div>
            </div>
            <div class="menu-item" v-bind:class="{active: (selectedItem == 14)}" v-on:click="selectItem(14)">
                <div class="menu-item-icon">
                    <div class="mi mi-24 mi-sidebar-finance"></div>
                </div>
                <div class="menu-item-title">
                        Báo cáo tài chính
                </div>
            </div>
        </div>
        
    </div>
</template>

<script>
export default {
    name: "MyNavbar",
    data: function(){
        return {
            selectedItem: 0,
        }
    },
    methods:{
        selectItem: function(item){
            this.selectedItem = item;
        }
    }
}
</script>

<style scoped>
#navbar{
    background: #393a3d;
    height: 100%;
    width: 178px;
    font-family: notosan-regular;
}
.logo-container{
    width: 100%;
    height: 48px;
    display: flex;
    align-items: center;
    justify-content: center;
}

.logo-img{
    height: 32px;
    width: 96px;
    background-image: url("../../assets/Logo_Module_TiengViet_White.66947422.svg");
    background-size: cover;
    background-repeat: no-repeat;
    cursor: pointer;
}

.menu-item-list{
    padding-top: 14px;
}

.menu-item{
    width: 178px;
    height: 42px;
    display: flex;
    align-items: center;
    cursor: pointer;
    position: relative;
}

.menu-item::before{
    content: "";
    position: absolute;
    width: 6px;
    height: 100%;
    background: rgb(51, 191, 34);
    top: 0;
    left: 0;
    display: none;
}

.menu-item:hover{
    background: rgba(255, 255, 255, 0.2);
}

.menu-item.active{
    background: rgba(255, 255, 255, 0.2);
}

.menu-item.active::before{
    display: block;
}

.menu-item .menu-item-icon{
    margin-right: 8px;
    margin-left: 16px;
}
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

.menu-item .menu-item-title{
    color: white;
    font-size: 13px;
    font-weight: 500;
    font-family: notosans-regular;
}

.menu-item.active .menu-item-title{
    font-family: notosans-bold;
}



</style>