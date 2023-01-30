<template>
  <div class="container">
    <div class="main-block">
      <div class="col-md-2 main-block-item">
        <select class="form-select form-select-lg mb-3" aria-label=".form-select-lg example" v-model="selectedFrom"
          v-on:change="changeDate">
          <option value="" disabled selected>Дата с </option>
          <option v-for="year, key in yearsFrom" :key="key" :value="year">{{ year }}</option>
        </select>
        <span v-show="isDataError" class="invalid-feedback"> Дата По не может быть больше даты С</span>
      </div>
      <div class="col-md-2 main-block-item">
        <select class="form-select form-select-lg mb-3" aria-label=".form-select-lg example" v-model="selectedTo"
          v-on:change="changeDate">
          <option value="" disabled selected>Дата по </option>
          <option v-for="year, key in yearsTo" :key="key" :value="year">{{ year }}</option>
        </select>
      </div>
      <div class="col-md-2 main-block-item">
        <select class="form-select form-select-lg mb-3" aria-label=".form-select-lg example" v-model="selectedClass">
          <option value="" disabled selected>Выберите класс </option>
          <option v-for="item, key in recclasses" :key="key" :value="item">{{ item }}</option>
        </select>
      </div>
      <div class="col-md-2 main-block-item">
        <div class="mb-3">
          <input type="text" v-model="name" @blur="validateName" class="form-control block-item-input"
            placeholder="Название метеорита">
          <span v-show="isEmptyError" class="invalid-feedback"> Имя не может быть пустым</span>
        </div>
      </div>
      <div class="col-md-3 row" style="margin-left: 20px;">
        <div class="col-md-6">
          <button :disabled="selectedFrom > selectedTo" type="button" v-on:click="applyFilter()"
            class="btn btn-primary btn-lg">Применить</button>
        </div>
        <div class="col-md-6">
          <button type="button" v-on:click="clearFilter()" class="btn btn-info btn-lg">Очистить</button>
        </div>
      </div>
    </div>
  </div>
  <GridModule :itemsLength="itemsLength" :years="years" :total="total" :totalMass="totalMass" />
</template>

<script>

import GridModule from '../components/Grid.vue'

export default {
  name: 'FilterModule',
  components: {
    GridModule
  },
  props: {

  },
  data() {
    return {
      yearsFrom: [],
      yearsTo: [],
      years: [],
      recclasses: [],
      selectedFrom: '',
      selectedTo: '',
      selectedClass: '',
      name: '',
      isDataError: false,
      isEmptyError: false,
      itemsLength: 0,
      total: 0,
      totalMass: 0,
    }
  },
  created() {
    fetch('https://localhost:7266/api/Star/get-years', {
      method: "GET",
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        let vm = this;
        vm.yearsFrom = data.Years;
        vm.yearsTo = data.Years;
        console.log(data);
      })
      .catch((error) => {
        console.log(error)
      })

      fetch('https://localhost:7266/api/Star/get-classes', {
      method: "GET",
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        let vm = this;
        vm.recclasses = data.Classes;
      })
      .catch((error) => {
        console.log(error)
      })

  },
  methods: {
    changeDate() {
      this.disableAllError();
      this.isDataError = false;
      if (this.selectedTo) {
        if (this.selectedFrom > this.selectedTo) {
          this.isDataError = true;
        }
      }
    },
    applyFilter() {
      let name = this.name.trim();
      if (this.selectedFrom > this.selectedTo) {
        this.isDataError = true;
      }

      if (!name.length && !this.selectedFrom && !this.selectedTo && !this.recclasses) {
        this.isEmptyError = true;
        return;
      }


      this.disableAllError();
      this.getItemsData();
    },
    validateName() {
      this.disableAllError();

      let name = this.name;
      if (name.length == 0) {
        this.disableAllError();
        this.isEmptyError = true;
        return;
      }

      if (name.length) {
        let name = this.name.trim();
        if (!name.length) {
          this.disableAllError();
          return;
        }
      }
    },
    disableAllError() {
      this.isEmptyError = false;
    },
    clearFilter() {
      this.selectedFrom = '';
      this.selectedTo = '';
      this.selectedClass = '';
      this.name = '';
      this.disableAllError();
      this.years = [];
      this.itemsLength = 0;
      this.total = 0;
    },
    getItemsData() {

      console.log(this.selectedClass);
      fetch('https://localhost:7266/api/Star/get-stars-filter', {
        method: "POST",
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(
          {
            from: this.selectedFrom,
            to: this.selectedTo,
            name: this.name,
            reclass: this.selectedClass
          })
      })
        .then((response) => {
          return response.json();
        })
        .then((data) => {
          let vm = this;
          vm.years = data.StarGroupVMs;
          vm.itemsLength = data.Total;
          vm.total = data.Total;
          vm.totalMass = data.TotalMass;
        })
        .catch((error) => {
          console.log(error)
        })
    }
  }


}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.invalid-feedback {
  display: block;
}

.main-block-item {
  margin-left: 20px;
}

.main-block {
  display: flex;
  justify-content: flex-start;
}

.block-item-input {
  height: 48px;
}

.btn-group {
  margin-left: 20px;
}

h3 {
  margin: 40px 0 0;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
