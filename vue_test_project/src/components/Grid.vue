<template>
    <div class="container">
        <table class="table mt-5" v-if="total > 0">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Год</th>
                    <th scope="col">Количество метеоритов</th>
                    <th scope="col">Суммарная масса</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in years" :key="item.Id">
                    <th scope="row">{{ item.Id }}</th>
                    <td>{{ item.Year }}</td>
                    <td>{{ item.TotalCount }}</td>
                    <td>{{ item.TotalSumMass }}</td>
                </tr>
            </tbody>
            <tfoot>
                <tr class="table-info">
                    <td> </td>
                    <td>Total</td>
                    <td>{{ total }}</td>
                    <td>{{ totalMass }}</td>
                </tr>
            </tfoot>
        </table>
        <div v-else> Данных нет</div>
    </div>


</template>

<script>
export default {
    name: 'GridModule',
    props: ['itemsLength', 'years', 'total', 'totalMass'],
    data() {
        return {
            items: this.years
        }
    },
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
