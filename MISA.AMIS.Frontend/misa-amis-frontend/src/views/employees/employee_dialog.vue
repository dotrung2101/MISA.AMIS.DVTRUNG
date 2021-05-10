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
                        <input type="text" id="txt-employee-code" style="width: 150px; margin-right: 6px">
                    </div>
                    <div class="form-element">
                        <label for="txt-employee-name">Tên <span>*</span></label>
                        <input type="text" id="txt-employee-name" style="width: 240px; margin-right: 26px">
                    </div>
                    <div class="form-element">
                        <label for="txt-employee-date-of-birth">Ngày sinh</label>
                        <input type="date" id="txt-employee-date-of-birth" style="width: 160px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label >Giới tính</label>
                        <div class="container-radio">
                            <input type="radio" id="male" name="gender" value="male">
                            <label for="male">Nam</label><br>
                            <input type="radio" id="female" name="gender" value="female">
                            <label for="female">Nữ</label><br>
                            <input type="radio" id="other" name="gender" value="other">
                            <label for="other">Khác</label>
                        </div>
                    </div>
                </div>
                <div class="horizontal">
                    <div class="form-element">
                        <label for="cb-department">Đơn vị <span>*</span></label>
                        <select name="department" id="cb-department" style="width: 440px; margin-right: 26px">
                            <option value="1">Demo</option>
                            <option value="2">Nhân sự</option>
                        </select>
                    </div>
                    <div class="form-element">
                        <label>Số CMND</label>
                        <input type="text" id="txt-employee-IN" style="width: 200px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>Ngày cấp</label>
                        <input type="date" id="txt-employee-date-of-IN" style="width: 160px; margin-right: 12px">
                    </div>
                </div>

                <div class="horizontal">
                    <div class="form-element">
                        <label>Chức danh</label>
                        <input type="text" style="width: 420px; margin-right: 26px">
                    </div>
                    <div class="form-element">
                        <label>Nơi cấp</label>
                        <input type="text" style="width: 395px">
                    </div>
                </div>
                <div style="height: 20px"></div>
                <div class="horizontal">
                    <div class="form-element">
                        <label>Địa chỉ</label>
                        <input type="text" style="width: 865px">
                    </div>
                </div>
                <div class="horizontal">
                    <div class="form-element">
                        <label>ĐT di động</label>
                        <input type="text" style="width: 250px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>ĐT cố định</label>
                        <input type="text" style="width: 250px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>Email</label>
                        <input type="text" style="width: 250px; margin-right: 12px">
                    </div>
                </div>
                <div class="horizontal">
                    <div class="form-element">
                        <label>Tài khoản ngân hàng</label>
                        <input type="text" style="width: 250px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>Tên ngân hàng</label>
                        <input type="text" style="width: 250px; margin-right: 12px">
                    </div>
                    <div class="form-element">
                        <label>Chi nhánh</label>
                        <input type="text" style="width: 250px; margin-right: 12px">
                    </div>
                </div>
                <div class="line"></div>
                <div style="height: 20px"></div>
                <div class="horizontal">
                    <button class="second-button">Hủy</button>
                    <div style="flex: 1"></div>
                    <button class="second-button">Cất</button>
                    <div style="width: 12px"></div>
                    <button class="btn-primary">Cất và Thêm</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "EmployeeDialog",
    data: function(){
        return {
            isShow: false,
        }
    },
    methods: {
        show: function(){
            this.isShow = true;
        },
        close: function(){
            this.isShow = false;
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
</style>