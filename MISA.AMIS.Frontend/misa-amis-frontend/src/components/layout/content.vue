<template>
    <div id="content">
        <div class="body">
            <employee-list/>
        </div>
    </div>
</template>

<script>
import EmployeeList from '../../views/employees/employee_list.vue';

export default {
    name: "MyContent",
    components: {
        EmployeeList,
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
#content{
    background: #f4f5f8;
    height: calc(100vh - 34px);
    overflow: hidden;
}
.body{
    width: calc(100% - 40px);
    height: 100%;
    padding-left: 10px;
    padding-right: 30px;
    display: flex;
    flex-direction: column;
}

</style>