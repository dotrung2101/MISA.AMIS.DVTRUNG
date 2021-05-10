<template>
    <div id="header">
        <div class="header-icon mi mi-24 mi-three-stripes"></div>
        <div class="dialog-action-container" v-bind:class="{active: isToggleWorkOption}">
            <div class="dialog-content" v-on:click="toggleWorkOption()"> 
                <div class="header-branch-name">CÔNG TY CỔ PHẦN MISA</div>
                <div class="header-icon header-branch-icon mi mi-14 mi-chevron-right"></div>
            </div>
            <div class="dialog-action work-option">

            </div>
        </div>
        <div class="header-current-db">
            <div class="icon-header-current-db"></div>
            <div class="header-current-db-name">DC-02</div>
        </div>

        <div class="ms-input-container">
            <input class="ms-input" type="text" placeholder="Nhập từ khoá tìm kiếm">
            <div class="mi mi-16 mi-search icon-after"></div>
        </div>

        <div style="flex:1"></div>

        <div class="header-button">
            <div class="header-icon mi mi-24 mi-category"></div>
        </div>
        <div class="header-button">
            <div class="header-icon mi mi-24 mi-setting-nav"></div>
        </div>
        <div class="header-button">
            <div class="header-icon mi mi-24 mi-chat-nav"></div>
        </div>
        <div class="header-button">
            <div class="header-icon mi mi-24 mi-help-nav"></div>
        </div>
        <div class="header-button">
            <div class="header-icon mi mi-24 mi-bell-nav"></div>
        </div>
        <div class="dialog-action-container" v-bind:class="{active: isToggleMenuUser}">
            <div class="dialog-content" v-on:click="toggleMenuUser()"> 
                <div class="header-branch-name">Nguyễn Quang Minh</div>
                <div class="header-icon header-branch-icon mi mi-14 mi-chevron-right"></div>
            </div>
            <div class="dialog-action work-option">

            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "MyHeader",
    data: function(){
        return {
            isToggleWorkOption: false,
            isToggleMenuUser: false,
        }
    },
    methods: {
        toggleWorkOption: function(){
            this.isToggleWorkOption = !this.isToggleWorkOption;
        },
        toggleMenuUser: function(){
            this.isToggleMenuUser = !this.isToggleMenuUser;
        }
    }
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
#header{
    width: 100%;
    height: 48px;
    background: white;
    display: flex;
    align-items: center;
}

.header-icon{
    margin-right: 10px;
    margin-left: 10px;
}

.dialog-content{
    display: flex;
    align-items: center;
    height: 100%;
}

.header-branch-name {
    padding-left: 10px;
    overflow: hidden;
    white-space: nowrap;
    font-weight: 600;
    max-width: 200px;
    text-overflow: ellipsis;
    transition: all .2s ease;
    font-size: 14px;
    color: #111;
}

.header-branch-icon{
    transform: rotate(90deg);
    margin-left: 10px;
}

.work-option{
    width: 400px;
    height: 250px;
    color: #212111;
    top: 20px;
    left: -30px;
}

.header-current-db {
    display: flex;
    align-items: center;
    border: 1px solid #ebedf0;
    padding: 0 12px;
    border-radius: 40px;
    margin-left: 15px;
    font-size: 13px;
    cursor: pointer;
    height: 30px;
    margin-right: 10px;
}
.icon-header-current-db {
    width: 8px;
    height: 8px;
    background-color: #4ea344;
    border-radius: 50%;
    border: 1px solid #fff;
}
.header-current-db-name {
    padding-left: 7px;
    max-width: 200px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    transition: all .2s ease;
    color: #111;
}

.header-button{
    width: 44px;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    cursor: pointer;
}

.header-button:hover{
    background: rgb(51, 191, 34);
}

.header-button::before{
    content: "";
    width: 100%;
    height: 10px;
    position: absolute;
    top: 100%;
    left: 0;
    background: rgb(51, 191, 34);
    clip-path: polygon(50% 100%, 0 0, 100% 0);
    display: none;
}
.header-button:hover::before{
    display: block;
}

.header-button:hover .mi-category{
    background-position-y: -76px;
}
.header-button:hover .mi-setting-nav{
    background-position: -145px -88px;
}
.header-button:hover .mi-chat-nav{
    background-position: -368px -88px;
}
.header-button:hover .mi-help-nav{
    background-position: -200px -88px;
}
.header-button:hover .mi-bell-nav{
    background-position: -255px -88px;
}
</style>